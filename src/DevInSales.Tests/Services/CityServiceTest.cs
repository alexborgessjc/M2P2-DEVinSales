using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Tests.Services
{
    public class CityServiceTest
    {
        private AddressService _addressService;
        private CityService _cityService;
        public CityServiceTest()
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
            await _cityService.AddAsync(new City(2, "Cidade"));
            await _addressService.AddAsync(new Address("Rua 4", "321", 8, "Complemento 3", 2));
            await _addressService.AddAsync(new Address("Rua 5", "654", 9, "Complemento 1", 2));
            await _addressService.AddAsync(new Address("Rua 6", "987", 10, "Complemento 2", 2));
        }
        [Fact]
        public async Task GetById_ShouldReturnCity()
        {
            var result = await _cityService.GetById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
