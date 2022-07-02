using DevInSales.Core.Data.Context;
using DevInSales.EFCoreApi.Core.Interfaces;

namespace DevInSales.Core.Entities
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public int CriarUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }


        public User? ObterPorId(int id)
        {
            return _context.Users.Find(id);
        }


        public List<User> ObterUsers(string? name, string? DataMin, string? DataMax)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.ToUpper().Contains(name.ToUpper()));
            if (!string.IsNullOrEmpty(DataMin))
                query = query.Where(p => p.BirthDate >= DateTime.Parse(DataMin));
            if (!string.IsNullOrEmpty(DataMax))
                query = query.Where(p => p.BirthDate <= DateTime.Parse(DataMax));

            return query.ToList();
        }
        public void RemoverUser(int id)
        {
            if (id >= 0)
            {
                var user = _context.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                    _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}