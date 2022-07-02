using DevInSales.Core.Entities;

namespace DevInSales.Core.Data.Dtos
{
    public class ReadState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public static ReadState? StateToReadState(State? state)
        {
            if (state == null)
                return null;
            return new ReadState
            {
                Id = state.Id,
                Name = state.Name,
                Initials = state.Initials
            };
        }

        internal static Task<ReadCityState?> StateToReadStateAsync(State? state)
        {
            throw new NotImplementedException();
        }
    }
}
