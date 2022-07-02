using DevInSales.Core.Data.Context;
using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Core.Services
{
    public class CityService : ICityService
    {
        private readonly DataContext _context;

        public CityService(DataContext context)
        {
            _context = context;
        }

        //public List<ReadCity> GetAll(int stateId, string? name)
        public async Task<IEnumerable<ReadCity>> GetAll(int stateId, string? name)
        {
            return await _context.Cities
                .Where(
                    p =>
                        p.StateId == stateId
                        && (
                            !String.IsNullOrEmpty(name)
                                ? p.Name.ToUpper().Contains(name.ToUpper())
                                : true
                        )
                )
                .Select(c => ReadCity.CityToReadCity(c))
                .ToListAsync();
        }

        //public ReadCity GetById(int cityId)
        public async Task<ReadCity?>  GetById(int cityId)
        {
            var city = _context.Cities
                .Include(p => p.State)
                .FirstOrDefault(p => p.Id == cityId);

            return ReadCity.CityToReadCity(city);
        }

        public async Task AddAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }
    }
}
