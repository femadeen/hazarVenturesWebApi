using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HazarVenturesWebApi.Implementations.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HazarVenturesDbContext _context;
        public RoleRepository(HazarVenturesDbContext conext)
        {
            _context = conext;
        }
        public async Task<Role> AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            _context.SaveChanges();
            return role;
        }

        public async Task<bool> DeleteRole(Role role )                     
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }

        public async Task<Role> FindRoleById(int id)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == id);
            return role;
        }

        public async Task<Role> FindRoleByName(string name)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
            return role;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
    }
}
