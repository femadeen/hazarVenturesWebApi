using HazarVenturesWebApi.Dtos;
using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;
using System.Reflection.Metadata.Ecma335;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<BaseResponse> AddDepartment(RegisterDepartmentRequestModel model)
        {
            var departmentExist = await _departmentRepository.Exists(model.Name);
            if(departmentExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Department Already Exist"
                };
            }
            var department = new Department
            {
                Name = model.Name,
                Description = model.Description,
            };
            await _departmentRepository.AddDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = "Department Registered Successfully"
            };
        }

        public async Task<DepartmentRepsonseModel> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.FindDepartmentById(id);
            if(department == null)
            {
                return new DepartmentRepsonseModel
                {
                    Status = false,
                    Message = " Department does not exist"
                };
            };
            await _departmentRepository.DeleteDepartment(department);
            return new DepartmentRepsonseModel
            {
                Status = true,
                Message = "Depoartment successfully deleted"
            };
        }

        public async Task<DepartmentsResponseModel> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            var returnedDeparments = departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
            }).ToList();
            return new DepartmentsResponseModel
            {
                Data = returnedDeparments,
                Status = true,
                Message = "All Department Retreived successfully"
            };
        }

        public async  Task<DepartmentRepsonseModel> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.FindDepartmentById(id);
            if(department == null)
            {
                return new DepartmentRepsonseModel
                {
                    Status = false,
                    Message = " Department does not exist"
                };
            }
            return new DepartmentRepsonseModel
            {
                Data = new DepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    Description = department.Description
                },
                Status = true,
                Message = " Department's details retreived Successfully"
            };
                
        }

        public async Task<BaseResponse> UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            var department = await _departmentRepository.FindDepartmentById(id);
            if(department == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Department does not exist"
                };
            }
            model.Name = department.Name;
            model.Description = department.Description;
            await _departmentRepository.UpdateDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = "Department Updated successfully"
            };
        }
    }
}
