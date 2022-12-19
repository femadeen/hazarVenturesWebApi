using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class UsersResponseModel : BaseResponse
    {
        public IEnumerable<UserDto> Data { get; set; } = new List<UserDto>();
    }
}
