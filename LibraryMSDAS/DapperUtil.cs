using Dapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;

namespace ClassLibrary1
{
    /// <summary>
    /// Tool class based on Dapper and Sqlite 
    /// </summary>
    public class DapperUtil
    {
        private static string dbConnectionStringConfigPath = null;
        private readonly static ConcurrentDictionary<string, bool> dbConnNamesCacheDic = new ConcurrentDictionary<string, bool>();

        private string dbConnectionName = null;
        private string dbConnectionString = null;
        private string dbProviderName = null;
        private IDbConnection dbConnection = null;
        private bool useDbTransaction = false;
        private IDbTransaction dbTransaction = null;

        #region private method
        private IDbConnection GetDbConnection()
        {
            bool needCreateNew = false;
            if (dbConnection== null || string.IsNullOrWhiteSpace(dbConnection.ConnectionString)) 
            { 
                needCreateNew= true;
            }
            if (needCreateNew)
            {
                dbConnectionString = GetDbConnectionString(dbConnectionName, out dbProviderName);
                if (dbProviderName.Equals("System.Data.SQLite", StringComparison.OrdinalIgnoreCase))
                {
                    dbConnection = new SQLiteConnection(dbConnectionString);
                }
                else
                {
                    var dbProviderFactory = DbProviderFactories.GetFactory(dbProviderName);
                    dbConnection = dbProviderFactory.CreateConnection();
                    dbConnection.ConnectionString = dbConnectionString;
                }
                
                //dbConnectionString = ConfigurationManager.ConnectionStrings[dbConnectionName].ConnectionString;
                //dbConnection = new SQLiteConnection(dbConnectionString);
            }
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            return dbConnection;
        }

        private string GetDbConnectionString(string dbConnName, out string dbProviderName)
        {
            //If a specified connection string configuration file path is provided, create a cache dependency that becomes invalid once the configuration file is modified, and then re-read the file.
            string[] connInfos = MemoryCacheUtil.GetOrAddCacheItem(dbConnName, () =>
            {
                var connStrSettings = ConfigUtil.GetConnectionStringSetting(dbConnName, DapperUtil.DbConnectionStringConfigPath);
                string dbProdName = connStrSettings.ProviderName;
                string dbConnStr = connStrSettings.ConnectionString;
                //LogUtil.Info(string.Format("SqlDapperUtil.GetDbConnectionString>Reading connectiong string node[{0}]:{1},ProviderName:{2}", dbConnName, dbConnStr, dbProdName), "SqlDapperUtil.GetDbConnectionString");
                return new[] { dbConnStr, dbProdName };
            }, DapperUtil.DbConnectionStringConfigPath);

            dbProviderName = connInfos[1];
            return connInfos[0];
        }

        private T UseDbConnection<T>(Func<IDbConnection, T> queryOrExecSqlFunc)
        {
            IDbConnection dbConn = null;

            try
            {
                Type modelType = typeof(T);
                var typeMap = Dapper.SqlMapper.GetTypeMap(modelType);
                if (typeMap == null || !(typeMap is ColumnAttributeTypeMapper<T>))
                {
                    Dapper.SqlMapper.SetTypeMap(modelType, new ColumnAttributeTypeMapper<T>());
                }

                dbConn = GetDbConnection();
                if (useDbTransaction && dbTransaction == null)
                {
                    dbTransaction = GetDbTransaction();
                }

                return queryOrExecSqlFunc(dbConn);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dbTransaction == null && dbConn != null)
                {
                    CloseDbConnection(dbConn);
                }
            }
        }

        private void CloseDbConnection(IDbConnection dbConn, bool disposed = false)
        {
            if (dbConn != null)
            {
                if (disposed && dbTransaction != null)
                {
                    dbTransaction.Rollback();
                    dbTransaction.Dispose();
                    dbTransaction = null;
                }

                if (dbConn.State != ConnectionState.Closed)
                {
                    dbConn.Close();
                }
                dbConn.Dispose();
                dbConn = null;
            }
        }

        /// <summary>
        /// Obtain a transaction object (if you need to ensure the consistency of multiple execution statements, it is necessary to use a transaction)
        /// </summary>
        /// <param name="il"></param>
        /// <returns></returns>
        private IDbTransaction GetDbTransaction(IsolationLevel il = IsolationLevel.Unspecified)
        {
            return GetDbConnection().BeginTransaction(il);
        }

        private DynamicParameters ToDynamicParameters(Dictionary<string, object> paramDic)
        {
            return new DynamicParameters(paramDic);
        }



        #endregion

        public static string DbConnectionStringConfigPath
        {
            get
            {
                if (string.IsNullOrEmpty(dbConnectionStringConfigPath))//If there is no config file, default config file is used
                {
                    // dbConnectionStringConfigPath = BaseUtil.GetConfigPath();
                    dbConnectionStringConfigPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                }

                return dbConnectionStringConfigPath;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !File.Exists(value))
                {
                    throw new FileNotFoundException(" The database connectstring is not existed:" + value);
                }

                //If the config file is changed, the connectiong string will be changed probly.All connection string cache need to be refreshed.
                if (!string.Equals(dbConnectionStringConfigPath, value, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var item in dbConnNamesCacheDic)
                    {
                        MemoryCacheUtil.RemoveCacheItem(item.Key);
                    }
                }

                dbConnectionStringConfigPath = value;
            }
        }

        public DapperUtil(string connName)
        {
            dbConnectionName = connName;
            if (!dbConnNamesCacheDic.ContainsKey(connName)) //If connection string is not existed in static cache,add conncection string into static cache
            {
                dbConnNamesCacheDic[connName] = true;
            }

        }


        /// <summary>
        /// Use transaction
        /// </summary>
        public void UseDbTransaction()
        {
            useDbTransaction = true;
        }


        /// <summary>
        /// Get one value. The parameter "param" can be either an SQL parameter or an anonymous object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T GetValue<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return UseDbConnection((dbConn) =>
            {
                return dbConn.ExecuteScalar<T>(sql, param, dbTransaction, commandTimeout, commandType);
            });
        }

        /// <summary>
        /// Get first row,The parameter "param" can be either an SQL parameter or an anonymous object
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Dictionary<string, dynamic> GetFirstValues(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return UseDbConnection((dbConn) =>
            {
                Dictionary<string, dynamic> firstValues = new Dictionary<string, dynamic>();
                List<string> indexColNameMappings = new List<string>();
                int rowIndex = 0;
                using (var reader = dbConn.ExecuteReader(sql, param, dbTransaction, commandTimeout, commandType))
                {
                    while (reader.Read())
                    {
                        if ((++rowIndex) > 1) break;
                        if (indexColNameMappings.Count == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                indexColNameMappings.Add(reader.GetName(i));
                            }
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            firstValues[indexColNameMappings[i]] = reader.GetValue(i);
                        }
                    }
                    reader.Close();
                }

                return firstValues;

            });
        }

        /// <summary>
        /// Get a object,The parameter "param" can be either an SQL parameter or an anonymous object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T GetModel<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) where T : class
        {
            return UseDbConnection((dbConn) =>
            {
                return dbConn.QueryFirstOrDefault<T>(sql, param, dbTransaction, commandTimeout, commandType);
            });
        }

        /// <summary>
        /// Get a object list, The parameter "param" can be either an SQL parameter or an anonymous object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public List<T> GetModelList<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) where T : class
        {
            return UseDbConnection((dbConn) =>
            {
                return dbConn.Query<T>(sql, param, dbTransaction, buffered, commandTimeout, commandType).ToList();
            });
        }

        /// <summary>
        /// Retrieve all data that meets the conditions and dynamically build a Model class delegate to create the appropriate return result 
        /// Applicable for temporary results without corresponding model entity classes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buildModelFunc"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T GetDynamicModel<T>(Func<IEnumerable<dynamic>, T> buildModelFunc, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            var dynamicResult = UseDbConnection((dbConn) =>
            {
                return dbConn.Query(sql, param, dbTransaction, buffered, commandTimeout, commandType);
            });

            return buildModelFunc(dynamicResult);
        }

        /// <summary>
        /// Retrieve a list of all specified return result objects that meet the conditions (composite objects such as one-to-many, one-to-one). 
        /// The parameter "param" can be either an SQL parameter or an anonymous object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="types"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>

        public List<T> GetMultModelList<T>(string sql, Type[] types, Func<object[], T> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return UseDbConnection((dbConn) =>
            {
                return dbConn.Query<T>(sql, types, map, param, dbTransaction, buffered, splitOn, commandTimeout, commandType).ToList();
            });
        }




        /// <summary>
        /// Execute an SQL command (CRUD) with the parameter "param" that can be either an SQL parameter or an entity class to be added.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public bool ExecuteCommand(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return UseDbConnection((dbConn) =>
            {
                int result = dbConn.Execute(sql, param, dbTransaction, commandTimeout, commandType);
                return (result > 0);
            });
        }

        /// <summary>
        /// Perform bulk data transfer using SqlBulkCopy for fast and bulk insertion into a specified destination table, along with batch deletion using SqlDataAdapter.
        /// </summary>
        public bool BatchMoveData(string srcSelectSql, string srcTableName, List<SqlParameter> srcPrimarykeyParams, string destConnName, string destTableName)
        {

            using (SqlDataAdapter srcSqlDataAdapter = new SqlDataAdapter(srcSelectSql, GetDbConnectionString(dbConnectionName, out dbProviderName)))
            {
                DataTable srcTable = new DataTable();
                SqlCommand deleteCommand = null;
                try
                {
                    srcSqlDataAdapter.AcceptChangesDuringFill = true;
                    srcSqlDataAdapter.AcceptChangesDuringUpdate = false;
                    srcSqlDataAdapter.Fill(srcTable);

                    if (srcTable == null || srcTable.Rows.Count <= 0) return true;

                    string notExistsDestSqlWhere = null;
                    string deleteSrcSqlWhere = null;

                    for (int i = 0; i < srcPrimarykeyParams.Count; i++)
                    {
                        string keyColName = srcPrimarykeyParams[i].ParameterName.Replace("@", "");
                        notExistsDestSqlWhere += string.Format(" AND told.{0}=tnew.{0}", keyColName);
                        deleteSrcSqlWhere += string.Format(" AND {0}=@{0}", keyColName);
                    }

                    string dbProviderName2 = null;
                    using (var destConn = new SqlConnection(GetDbConnectionString(destConnName, out dbProviderName2)))
                    {
                        destConn.Open();

                        string tempDestTableName = "#temp_" + destTableName;
                        destConn.Execute(string.Format("select top 0 * into {0} from {1}", tempDestTableName, destTableName));
                        string destInsertCols = null;
                        using (var destSqlBulkCopy = new SqlBulkCopy(destConn))
                        {
                            try
                            {
                                destSqlBulkCopy.BulkCopyTimeout = 120;
                                destSqlBulkCopy.DestinationTableName = tempDestTableName;
                                foreach (DataColumn col in srcTable.Columns)
                                {
                                    destSqlBulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                                    destInsertCols += "," + col.ColumnName;
                                }

                                destSqlBulkCopy.BatchSize = 1000;
                                destSqlBulkCopy.WriteToServer(srcTable);
                            }
                            catch (Exception ex)
                            {
                                //LogUtil.Error("SqlDapperUtil.BatchMoveData.SqlBulkCopy:" + ex.ToString(), "SqlDapperUtil.BatchMoveData");
                            }

                            destInsertCols = destInsertCols.Substring(1);

                            destConn.Execute(string.Format("insert into {1}({0}) select {0} from {2} tnew where not exists(select 1 from {1} told where {3})",
                                             destInsertCols, destTableName, tempDestTableName, notExistsDestSqlWhere.Trim().Substring(3)), null, null, 100);
                        }
                        destConn.Close();
                    }

                    deleteCommand = new SqlCommand(string.Format("DELETE FROM {0} WHERE {1}", srcTableName, deleteSrcSqlWhere.Trim().Substring(3)), srcSqlDataAdapter.SelectCommand.Connection);
                    deleteCommand.Parameters.AddRange(srcPrimarykeyParams.ToArray());
                    deleteCommand.UpdatedRowSource = UpdateRowSource.None;
                    deleteCommand.CommandTimeout = 200;

                    srcSqlDataAdapter.DeleteCommand = deleteCommand;
                    foreach (DataRow row in srcTable.Rows)
                    {
                        row.Delete();
                    }

                    srcSqlDataAdapter.UpdateBatchSize = 1000;
                    srcSqlDataAdapter.Update(srcTable);
                    srcTable.AcceptChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    //LogUtil.Error("SqlDapperUtil.BatchMoveData:" + ex.ToString(), "SqlDapperUtil.BatchMoveData");
                    return false;
                }
                finally
                {
                    if (deleteCommand != null)
                    {
                        deleteCommand.Parameters.Clear();
                    }
                }
            }

        }

        /// <summary>
        /// Perform bulk data copying by inserting the batch results obtained from executing an SQL statement in the source database into the destination table in the destination database.
        /// </summary>
        public TResult BatchCopyData<TResult>(string srcSelectSql, string destConnName, string destTableName, IDictionary<string, string> colMappings, Func<IDbConnection, TResult> afterCoppyFunc)
        {

            using (SqlDataAdapter srcSqlDataAdapter = new SqlDataAdapter(srcSelectSql, GetDbConnectionString(dbConnectionName, out dbProviderName)))
            {
                DataTable srcTable = new DataTable();
                TResult copyResult = default(TResult);
                try
                {
                    srcSqlDataAdapter.AcceptChangesDuringFill = true;
                    srcSqlDataAdapter.AcceptChangesDuringUpdate = false;
                    srcSqlDataAdapter.Fill(srcTable);

                    if (srcTable == null || srcTable.Rows.Count <= 0) return copyResult;


                    string dbProviderName2 = null;
                    using (var destConn = new SqlConnection(GetDbConnectionString(destConnName, out dbProviderName2)))
                    {
                        destConn.Open();
                        string tempDestTableName = "#temp_" + destTableName;
                        destConn.Execute(string.Format("select top 0 * into {0} from {1}", tempDestTableName, destTableName));
                        bool bcpResult = false;
                        using (var destSqlBulkCopy = new SqlBulkCopy(destConn))
                        {
                            try
                            {
                                destSqlBulkCopy.BulkCopyTimeout = 120;
                                destSqlBulkCopy.DestinationTableName = tempDestTableName;
                                foreach (var col in colMappings)
                                {
                                    destSqlBulkCopy.ColumnMappings.Add(col.Key, col.Value);
                                }

                                destSqlBulkCopy.BatchSize = 1000;
                                destSqlBulkCopy.WriteToServer(srcTable);
                                bcpResult = true;
                            }
                            catch (Exception ex)
                            {
                                //LogUtil.Error("SqlDapperUtil.BatchMoveData.SqlBulkCopy:" + ex.ToString(), "SqlDapperUtil.BatchMoveData");
                            }
                        }

                        if (bcpResult)
                        {
                            copyResult = afterCoppyFunc(destConn);
                        }

                        destConn.Close();
                    }

                    return copyResult;
                }
                catch (Exception ex)
                {
                    //LogUtil.Error("SqlDapperUtil.BatchCopyData:" + ex.ToString(), "SqlDapperUtil.BatchCopyData");
                    return copyResult;
                }
            }

        }


        /// <summary>
        /// If you are using transactions, make sure to call the method to commit all operations at the end.
        /// </summary>
        /// <param name="dbTransaction"></param>
        public void Commit()
        {
            try
            {
                if (dbTransaction.Connection != null && dbTransaction.Connection.State != ConnectionState.Closed)
                {
                    dbTransaction.Commit();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dbTransaction.Connection != null)
                {
                    CloseDbConnection(dbTransaction.Connection);
                }
                dbTransaction.Dispose();
                dbTransaction = null;
                useDbTransaction = false;

                if (dbConnection != null)
                {
                    CloseDbConnection(dbConnection);
                }
            }
        }

        /// <summary>
        /// If you encounter an error or need to abort the execution while using transactions, you should call the method to perform a rollback operation.
        /// </summary>
        /// <param name="dbTransaction"></param>
        public void Rollback()
        {
            try
            {
                if (dbTransaction.Connection != null && dbTransaction.Connection.State != ConnectionState.Closed)
                {
                    dbTransaction.Rollback();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dbTransaction.Connection != null)
                {
                    CloseDbConnection(dbTransaction.Connection);
                }

                dbTransaction.Dispose();
                dbTransaction = null;
                useDbTransaction = false;
            }
        }

        ~DapperUtil()
        {
            try
            {
                CloseDbConnection(dbConnection, true);
            }
            catch
            { }
        }

    }
}

