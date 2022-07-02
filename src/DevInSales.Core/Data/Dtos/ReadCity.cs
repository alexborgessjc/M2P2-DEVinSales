using DevInSales.Core.Entities;
namespace DevInSales.Core.Data.Dtos
{
    public class ReadCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReadCityState State { get; set; }

        public static ReadCity? CityToReadCity(City? city)
        {
            if (city == null)
                return null;
            return new ReadCity
            {
                Id = city.Id,
                Name = city.Name,
                State = new ReadCityState
                {
                    Id = city.State.Id,
                    Name = city.State.Name,
                    Initials = city.State.Initials
                }
            };
        }
    }
}
