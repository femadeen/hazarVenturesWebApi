using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(LoginRequestModel model);
        Task<UsersResponseModel> GetAllUSers();
        Task<UserResponseModel> GetUserById(int id);
        Task<UserResponseModel> ChangePassword(int id, ChangePasswordRequestModel request);
    }
}
