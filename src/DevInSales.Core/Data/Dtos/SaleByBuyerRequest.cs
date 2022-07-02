using DevInSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Dtos
{
    public class SaleByBuyerRequest
    {
        public SaleByBuyerRequest(int sellerId, DateTime saleDate)
        {
            SellerId = sellerId;
            SaleDate = saleDate;
        }

        public int SellerId { get; private set; }
        public DateTime SaleDate { get; private set; }

        public Sale ConvertToEntity(int userId)
        {
            return new Sale(userId, SellerId, SaleDate);
        }
    }
}
