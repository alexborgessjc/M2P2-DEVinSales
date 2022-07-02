using DevInSales.Core.Data.Dtos;

namespace DevInSales.Core.Interfaces
{
    public interface IStateService
    {
        //List<ReadState> GetAll(string? name);
        public Task<IEnumerable<ReadState>> GetAll(string? name);
        //ReadState GetById(int stateId);
        public Task<ReadState>? GetById(int stateId);
    }
}