using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;

namespace DevInSales.Core.Interfaces
{
    public interface IAddressService
    {
        public Task <IEnumerable<Address>> GetAll(int? stateId, int? cityId, string? street, string? cep);
        public Task<Address>? GetById(int addressId);
        public Task AddAsync(Address address);
        public Task Delete(Address address);
        public Task Update(Address address);        
    }
}