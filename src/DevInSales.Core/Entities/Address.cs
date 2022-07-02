using DevInSales.Core.Data.Dtos;

namespace DevInSales.Core.Entities
{
  public class Address : Entity
  {
    public int CityId { get; private set; }
    public string Street { get; set; }
    public string Cep { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }
    public City City { get; set; }

    public Address(string street, string cep, int number, string complement, int cityId)
    {
      Street = street;
      Cep = cep;
      Number = number;
      Complement = complement;
      CityId = cityId;
    }
  }
}
