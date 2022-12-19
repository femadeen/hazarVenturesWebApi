using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class CoursesResponseModel : BaseResponse
    {
        public IEnumerable<CourseDto> Data { get; set; } = new List<CourseDto>();
    }
}
