using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ConfigUtil
    {
        /// <summary>
        /// Obtain the configuration file objec Configuration
        /// </summary>
        /// <param name="configPath">To specify the path of the configuration file to manage, if it is empty or doesn't exist, the default configuration file path is used.</param>
        /// <returns></returns>
        private static Configuration GetConfiguration(string configPath = null)
        {
            if (!string.IsNullOrEmpty(configPath) && File.Exists(configPath))
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = configPath;
                return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            }
            else
            {
                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
        }


        /// <summary>
        /// Retrieve give configuration file + the setting of configuration file
        /// </summary>
        public static string GetAppSettingValue(string key, string defaultValue = null, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var appSetting = config.AppSettings.Settings[key];
            return appSetting.Value;
        }


        /// <summary>
        /// Set configuration value (update if it exists, add if it doesn't exist).
        /// </summary>
        public static void SetAppSettingValue(string key, string value, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var setting = config.AppSettings.Settings[key];
            if (setting == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                setting.Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Delete a configuration value
        /// </summary>
        public static void RemoveAppSetting(string key, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            config.AppSettings.Settings.Remove(key);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Set configuration values (update if it exists, add if it doesn't exist).
        /// </summary>
        public static void SetAppSettingValues(IEnumerable<KeyValuePair<string, string>> settingValues, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            foreach (var item in settingValues)
            {
                var setting = config.AppSettings.Settings[item.Key];
                if (setting == null)
                {
                    config.AppSettings.Settings.Add(item.Key, item.Value);
                }
                else
                {
                    setting.Value = item.Value;
                }
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Retrieve all configuration values
        /// </summary>
        public static Dictionary<string, string> GetAppSettingValues(string configPath = null)
        {
            Dictionary<string, string> settingDic = new Dictionary<string, string>();
            var config = GetConfiguration(configPath);
            var settings = config.AppSettings.Settings;
            foreach (string key in settings.AllKeys)
            {
                settingDic[key] = settings[key].ToString();
            }
            return settingDic;
        }

        /// <summary>
        /// Delete configuration values
        /// </summary>
        public static void RemoveAppSettings(string configPath = null, params string[] keys)
        {
            var config = GetConfiguration(configPath);
            if (keys != null)
            {
                foreach (string key in keys)
                {
                    config.AppSettings.Settings.Remove(key);
                }
            }
            else
            {
                config.AppSettings.Settings.Clear();
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }



        /// <summary>
        /// Retrieve connection string
        /// </summary>
        public static string GetConnectionString(string name, string defaultconnStr = null, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var connStrSettings = config.ConnectionStrings.ConnectionStrings[name];
            if (connStrSettings == null)
            {
                return defaultconnStr;
            }
            return connStrSettings.ConnectionString;
        }

        /// <summary>
        /// Retrive configuration file + connection string
        /// </summary>
        public static ConnectionStringSettings GetConnectionStringSetting(string name, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var connStrSettings = config.ConnectionStrings.ConnectionStrings[name];
            return connStrSettings;
        }

        /// <summary>
        /// set connection string value () (update if it exists, add if it doesn't exist).
        /// </summary>
        public static void SetConnectionString(string name, string connstr, string provider, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            ConnectionStringSettings connStrSettings = config.ConnectionStrings.ConnectionStrings[name];
            if (connStrSettings != null)
            {
                connStrSettings.ConnectionString = connstr;
                connStrSettings.ProviderName = provider;
            }
            else
            {
                connStrSettings = new ConnectionStringSettings(name, connstr, provider);
                config.ConnectionStrings.ConnectionStrings.Add(connStrSettings);
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Delete a connection string setting 
        /// </summary>
        public static void RemoveConnectionString(string name, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            config.ConnectionStrings.ConnectionStrings.Remove(name);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Retrive all connection string settings
        /// </summary>
        public static Dictionary<string, ConnectionStringSettings> GetConnectionStringSettings(string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var connStrSettingDic = new Dictionary<string, ConnectionStringSettings>();
            var connStrSettings = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings item in connStrSettings)
            {
                connStrSettingDic[item.Name] = item;
            }
            return connStrSettingDic;
        }

        /// <summary>
        /// set connection string values () (update if it exists, add if it doesn't exist).
        /// </summary>
        public static void SetConnectionStrings(IEnumerable<ConnectionStringSettings> connStrSettings, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            foreach (var item in connStrSettings)
            {
                ConnectionStringSettings connStrSetting = config.ConnectionStrings.ConnectionStrings[item.Name];
                if (connStrSetting != null)
                {
                    connStrSetting.ConnectionString = item.ConnectionString;
                    connStrSetting.ProviderName = item.ProviderName;
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Add(item);
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Delete connection string settings
        /// </summary>
        public static void RemoveConnectionStrings(string configPath = null, params string[] names)
        {
            var config = GetConfiguration(configPath);
            if (names != null)
            {
                foreach (string name in names)
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(name);
                }
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Clear();
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
