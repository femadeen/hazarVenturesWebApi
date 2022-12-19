using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;
using HazarVenturesWebApi.Models;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface ILecturerService
    {
        Task<BaseResponse> RegisterLecturer(RegisterLecturerRequestModel model);
        Task<BaseResponse> UpdateLecturer(int id, UpdateLecturerRequestModel model);
        Task<LecturerResponseModel> DeleteLecturer(int id);
        Task<LecturerResponseModel> GetLecturerById(int id);
        Task<LecturersResponseModel> GetAllLecturer();
    }
}
