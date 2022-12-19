using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class StudentResponseModel : BaseResponse 
    {
        public StudentDto Data { get; set; }
    }
}
