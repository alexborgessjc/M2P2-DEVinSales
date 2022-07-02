namespace DevInSales.Core.Entities
{
    public class State : Entity
    {
        public string Name { get; private set; }
        public string Initials { get; private set; }
        public List<City> Cities { get; set; }

        public State(int id, string name, string initials)
        {
            Id = id;
            Name = name;
            Initials = initials;
        }

    }
}
