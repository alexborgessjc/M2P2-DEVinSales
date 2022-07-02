using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Tests.Services
{
    public class AddressServiceTest
    {        
        private AddressService _addressService;
        private CityService _cityService;
        public AddressServiceTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DataContext(options);

            _cityService = new CityService(context);
            _addressService = new AddressService(context);

            Seed().Wait();
        }
        private async Task Seed()
        {
            await _cityService.AddAsync(new City(1, "Cidade"));
            await _addressService.AddAsync(new Address("Rua 1", "123", 8, "Complemento 1", 1));
            await _addressService.AddAsync(new Address("Rua 2", "456", 9, "Complemento 2", 1));
            await _addressService.AddAsync(new Address("Rua 3", "789", 10, "Complemento 3", 1));
        }

        [Fact]
        public async Task GetById_ShouldReturnAdreess()
        {           
                var result = await _addressService.GetById(1);

                Assert.NotNull(result);
                Assert.Equal(1, result.Id);            
        }

        [Theory]
        [InlineData(1, null, null, null)]
        [InlineData(null, 1, null, null)]        
        [InlineData(null, null, "Rua 1", null)]
        [InlineData(null, null, null, "123")]

        public async Task GetAll_ShouldReturnAdreess(int? stateId, int? cityId, string? street, string? cep)
        {                
                var result = await _addressService.GetAll(stateId, cityId, street, cep);

                Assert.NotEmpty(result);
                Assert.Contains(1, result.Select(x => x.CityId));
                Assert.Contains(1, result.Select(x => x.City.StateId));
                Assert.Contains("Rua 1", result.Select(x => x.Street));
                Assert.Contains("123", result.Select(x => x.Cep));
        }
        
        [Fact]
        public async Task Add_ShouldReturnAddress()
        {                         
                await _addressService.AddAsync(new Address("Rua 4", "123456888", 11, "Complemento 4", 1));
                var result = await _addressService.GetAll(null, null, "Rua 4", null);
                Assert.Equal("Rua 4", result.FirstOrDefault().Street);            
        }

        [Fact]
        public async Task Update_ShouldReturnAddress()
        {
            var result = await _addressService.GetById(1);
            result.Number = 99;

            await _addressService.Update(result);
            var resultAtualizado = await _addressService.GetById(1);
            Assert.Equal(99, resultAtualizado.Number);            
        }
    }
}