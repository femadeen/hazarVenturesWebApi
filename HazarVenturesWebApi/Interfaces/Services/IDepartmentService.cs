using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;
using HazarVenturesWebApi.Models;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<BaseResponse> AddDepartment(RegisterDepartmentRequestModel model);
        Task<BaseResponse> UpdateDepartment(int id, UpdateDepartmentRequestModel model);
        Task<DepartmentRepsonseModel> DeleteDepartment(int id);
        Task<DepartmentRepsonseModel> GetDepartmentById(int id);
        Task<DepartmentsResponseModel> GetAllDepartments();
    }
}
