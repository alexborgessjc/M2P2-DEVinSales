using DevInSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Dtos
{
    public class SaleBySellerRequest
    {
        public SaleBySellerRequest(int buyerId, DateTime saleDate)
        {
            BuyerId = buyerId;
            SaleDate = saleDate;
        }

        public int BuyerId { get; private set; }
        public DateTime SaleDate { get; private set; }

        public Sale ConvertToEntity(int userId)
        {
            return new Sale(BuyerId, userId, SaleDate);
        }

    }
}
