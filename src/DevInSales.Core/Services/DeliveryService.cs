using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;

using DevInSales.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Core.Services

{
    public class DeliveryService : IDeliveryService
    {
        private readonly DataContext _context;
        public DeliveryService(DataContext context)
        {
            _context = context;
        }
        public List<Delivery> GetBy(int? idAddress, int? saleId)
        {

            if (!idAddress.HasValue && !saleId.HasValue)
            {
                return _context.Deliveries
                .ToList();
            }
            return _context.Deliveries
                .Where(p => p.AddressId == idAddress || p.SaleId == saleId)
                .ToList();
        }
    }
}