using DevInSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Dtos
{
    public  class SaleProductRequest
    {

        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }


        public SaleProductRequest(int productId, decimal? unitPrice, int? amount)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Amount = amount;
        }


        public SaleProduct ConvertIntoSaleProduct(int saleId)
        {

            return new SaleProduct(saleId, ProductId, UnitPrice.Value, Amount.Value);

        }
    }
}
