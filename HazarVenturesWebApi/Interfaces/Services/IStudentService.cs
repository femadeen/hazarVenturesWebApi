using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;
using HazarVenturesWebApi.Models;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface IStudentService
    {
        Task<BaseResponse> AddStudent(RegisterStudentRequstModel model);
        Task<BaseResponse> UpdateStudent(int id, UpdateStudentRequestModel model);
        Task<StudentResponseModel> DeleteStudent(int id);
        Task<StudentResponseModel> GetStudentById(int id);
        Task<StudentsResponseModel> GetAllStudents();
    }
}
