using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> CreateRole(CreateRoleRequestModel model)
        {
            var role = new Role
            {
                Name = model.RoleName,
            };
            await _roleRepository.AddRole(role);
            return new BaseResponse
            {
                Status = true,
                Message = " Role craeted sucessfully"
            };
        }
    }
}
