using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class SaleHistory
    {
        private int _bookSaleId;
        private int _supplierId;
        private int _bookInfoId;
        private int _quantity;

        private double getSubTotal()
        {
            if (bookInfo!=null) 
            {
                return bookInfo.Price * Quantity;
            }
            else
            {
                return 0;
            }
        }
        private DateTime? _saleDate;
        private DateTime? _endSaleDate;
        public int BookSaleId { get => _bookSaleId; set => _bookSaleId = value; }
        public int SupplierId { get => _supplierId; set => _supplierId = value; }
        public int BookInfoId { get => _bookInfoId; set => _bookInfoId = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public DateTime? SaleDate { get => _saleDate; set => _saleDate = value; }

        public BookInfo bookInfo { get; set; }
        public double subTotal { get => getSubTotal();}
        public DateTime? EndSaleDate { get => _endSaleDate; set => _endSaleDate = value; }
    }
}
