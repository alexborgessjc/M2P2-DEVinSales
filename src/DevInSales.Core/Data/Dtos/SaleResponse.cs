using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Dtos
{
    public class SaleResponse
    {
        public int SaleId { get; private set; }
        public string SellerName { get; private set; }
        public string BuyerName { get; private set; }
        public DateTime SaleDate { get; private set; }
        public List<SaleProductResponse> SaleProducts { get; private set; }

        public SaleResponse(int saleId, string sellerName, string buyerName, DateTime saleDate, List<SaleProductResponse> saleProducts)
        {
            SaleId = saleId;
            SellerName = sellerName;
            BuyerName = buyerName;
            SaleDate = saleDate;
            SaleProducts = saleProducts;
        }
    }
}
