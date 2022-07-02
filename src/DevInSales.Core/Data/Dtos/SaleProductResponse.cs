using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Dtos
{
    public class SaleProductResponse
    {

        public string ProductName { get; private set; }
        public int Amount { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Total { get; private set; }

        public SaleProductResponse(string productName, int amount, decimal unitPrice, decimal total)
        {
            ProductName = productName;
            Amount = amount;
            UnitPrice = unitPrice;
            Total = total;
        }    
    }
}
