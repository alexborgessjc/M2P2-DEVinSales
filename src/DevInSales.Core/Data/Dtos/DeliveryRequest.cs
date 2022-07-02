using DevInSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Dtos
{
    public class DeliveryRequest
    {
        public int AddressId { get; set; }
        public DateTime DeliveryForecast { get; set; }

        public DeliveryRequest(int addressId, DateTime deliveryForecast)
        {
            AddressId = addressId;
            DeliveryForecast = deliveryForecast;
        }

        public Delivery ConvertToEntity(int saleId)
        {
            return new Delivery(AddressId, saleId, DeliveryForecast);
        }

    }
}
