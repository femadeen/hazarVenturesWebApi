using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface ICourseService
    {
        Task<BaseResponse> RegisterCourse(RegisterCourseRequestModel model);
        Task<BaseResponse> UpdateCourse(int id, UpdateCourseRequestModel model);
        Task<CourseResponseModel> DeleteCourse(int id);
        Task<CourseResponseModel> GetCourseById(int id);
        Task<CoursesResponseModel> GetAllCourses();

    }
}
