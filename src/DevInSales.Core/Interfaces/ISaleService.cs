using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;


namespace DevInSales.Core.Interfaces
{
    public interface ISaleService
    {
        public SaleResponse GetSaleById(int id);
        
        public int CreateSaleByUserId(Sale sale);
        
        public List<Sale> GetSaleBySellerId(int? userId);

        public List<Sale> GetSaleByBuyerId(int? userId);
       
        public void UpdateUnitPrice(int saleId, int productId, decimal price);

        public void UpdateAmount(int saleId, int productId, int amount);

        public int CreateDeliveryForASale(Delivery delivery);

        public Delivery GetDeliveryById(int deliveryId);

    }
}