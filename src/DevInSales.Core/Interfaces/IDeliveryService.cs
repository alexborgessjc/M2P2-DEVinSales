using DevInSales.Core.Entities;


namespace DevInSales.Core.Interfaces
{
    public interface IDeliveryService
    {
        public List<Delivery> GetBy(int? idAddress, int? saleId);

    }
}