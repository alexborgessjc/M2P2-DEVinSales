using System.Text.Json.Serialization;
namespace DevInSales.Core.Entities
{
    public class City : Entity
    {
        public int StateId { get; private set; }
        public string Name { get; private set; }
        public State State { get; set; }

        [JsonIgnore]
        public List<Address> Addresses { get; private set; }

        public City(int stateId, string name)
        {
            StateId = stateId;
            Name = name;
        }
    }
}
