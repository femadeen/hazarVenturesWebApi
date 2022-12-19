using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class DepartmentsResponseModel : BaseResponse
    {
        public IEnumerable<DepartmentDto> Data { get; set; } = new List<DepartmentDto>();
    }
}
