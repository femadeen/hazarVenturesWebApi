using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class LecturersResponseModel : BaseResponse
    {
        public IEnumerable<LecturerDto> Data { get; set; } = new List<LecturerDto>();
    }
}
