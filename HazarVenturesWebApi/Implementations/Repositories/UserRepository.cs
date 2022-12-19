using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarVenturesWebApi.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HazarVenturesDbContext _context;
        public UserRepository(HazarVenturesDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<bool> DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
            return true;
        }

            public async Task<User>FindUserByEmail(string email)
            {
                var user = await _context.Users
                    .Include(r => r.Role)
                    .Include(u => u.Student)
                    .ThenInclude(s => s.Department)
                    .Include(u => u.Lecturer)
                    .ThenInclude(l => l.Department)
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
                return user;
            }
       

        public async Task<User> FindUserById(int id)
        {
            var user = await _context.Users
             .Include(r => r.Role)
             .Include(u => u.Student)
             .ThenInclude(s => s.Department)
             .Include(u => u.Lecturer)
             .ThenInclude(l => l.Department)
             .SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> UpdateUser(User user)
        {
             _context.Users.Update(user);
             _context.SaveChanges();
            return user;

        }
    }
}
