using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class CourseResponseModel : BaseResponse
    {
        public CourseDto Data { get; set; }
    }
}
