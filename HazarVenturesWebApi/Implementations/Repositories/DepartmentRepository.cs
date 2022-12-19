using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarVenturesWebApi.Implementations.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HazarVenturesDbContext _context;
        public DepartmentRepository(HazarVenturesDbContext context)
        {
            _context = context;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            _context.SaveChanges();
            return department;
        }

        public async Task<bool> DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Exists(string name)
        {
            var departement = await _context.Departments.AnyAsync(d => d.Name.ToLower() == name.ToLower());
            return departement;
        }

        public async  Task<Department> FindDepartmentById(int id)
        {
            var department = await _context.Departments.SingleOrDefaultAsync(d => d.Id == id);
            return department;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var departments =  await _context.Departments.ToListAsync();
            return departments;
        }

        public async Task<int> GetDepartmentCount()
        {
            var departmentCount = await _context.Departments.CountAsync();
            return departmentCount;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return department;
        }
    }
}
