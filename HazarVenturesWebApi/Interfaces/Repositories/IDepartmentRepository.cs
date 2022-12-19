using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> AddDepartment(Department department);
        Task<Department> FindDepartmentById(int id);
        Task<bool> DeleteDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<List<Department>> GetAllDepartments();
        Task<bool> Exists(string name);
        Task<int> GetDepartmentCount();
    }
}
