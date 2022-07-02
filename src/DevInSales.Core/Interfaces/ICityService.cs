using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;

namespace DevInSales.Core.Interfaces
{
    public interface ICityService
    {
        //List<ReadCity> GetAll(int stateId, string? name);
        //ReadCity GetById(int cityId);
        public Task<IEnumerable<ReadCity>> GetAll(int stateId, string? name);
        public Task<ReadCity>? GetById(int cityId);
        public Task AddAsync(City city);        
    }
}