using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class StudentsResponseModel : BaseResponse
    {
        public IEnumerable<StudentDto> Data {get; set;} = new List<StudentDto>(); 
    }
}
