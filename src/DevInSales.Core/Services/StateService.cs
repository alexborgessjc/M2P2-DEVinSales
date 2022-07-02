using DevInSales.Core.Data.Context;
using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Core.Services
{
    public class StateService : IStateService
    {
        private readonly DataContext _context;

        public StateService(DataContext context)
        {
            _context = context;
        }

        //public List<ReadState> GetAll(string? name)
        public async Task<IEnumerable<ReadState>> GetAll(string? name)
        {
            return await _context.States
                .Include(p => p.Cities)
                .Where(
                    p =>
                        !String.IsNullOrWhiteSpace(name)
                            ? p.Name.ToUpper().Contains(name.ToUpper())
                            : true
                )
                .Select(s => ReadState.StateToReadState(s))
                .ToListAsync();
        }

        //public ReadState GetById(int stateId)
        public async Task<ReadState?> GetById(int stateId)
        {
            var state = await _context.States.Include(p => p.Cities).FirstOrDefaultAsync(p => p.Id == stateId);
            return ReadState.StateToReadState(state);
        }       
    }
}
