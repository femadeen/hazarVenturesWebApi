using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface IRoleService
    {
        Task<BaseResponse> CreateRole(CreateRoleRequestModel model);
    }
}
