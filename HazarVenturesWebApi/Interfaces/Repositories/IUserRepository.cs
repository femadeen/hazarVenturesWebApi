using HazarVenturesWebApi.Entities;
using System.Threading.Tasks;

namespace HazarVenturesWebApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> FindUserById(int id);
        Task<User> FindUserByEmail(string email);
        Task<bool> DeleteUser(User user);
        Task<User> UpdateUser(User user);
        Task<List<User>> GetAllUsers();
    }
}
