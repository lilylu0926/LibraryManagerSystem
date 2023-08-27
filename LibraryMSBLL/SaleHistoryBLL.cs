using LibraryMS.DAS;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class SaleHistoryBLL
    {
        /// <summary>
        /// seach sale history of given supply with multi condition
        /// </summary>
        /// <param name="saleHistory"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public List<SaleHistory> getAllConditionsBySupplierId(SaleHistory saleHistory)
        {
            SaleHistoryDAS saleHistoryDAS = new SaleHistoryDAS();
            return saleHistoryDAS.getAllConditionsBySupplierId(saleHistory);
        }

        public bool deleteById(int bookSaleId)
        {
            SaleHistoryDAS saleHistoryDAS = new SaleHistoryDAS();
            return saleHistoryDAS.deleteById(bookSaleId);
        }
    }
}
