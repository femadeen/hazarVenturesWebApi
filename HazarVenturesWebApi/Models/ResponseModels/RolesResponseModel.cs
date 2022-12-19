using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class RolesResponseModel : BaseResponse 
    {
        public IEnumerable<RoleDto> Data { get; set; } = new List<RoleDto>();
    }
}
