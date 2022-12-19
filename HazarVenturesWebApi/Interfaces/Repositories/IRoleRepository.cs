using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> AddRole(Role role);
        Task<Role> FindRoleById(int id);
        Task<Role> FindRoleByName(string name);
        Task<bool> DeleteRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task<List<Role>> GetAllRoles();
    }
}
