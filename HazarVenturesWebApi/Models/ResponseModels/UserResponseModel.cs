using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class UserResponseModel : BaseResponse 
    {
        public UserDto Data { get; set; }  
        public string Token { get; set; }
    }
}
