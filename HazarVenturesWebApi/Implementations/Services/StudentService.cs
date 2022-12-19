using HazarVenturesWebApi.Dtos;
using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> AddStudent(RegisterStudentRequstModel model)
        {
            var studentExist = await _studentRepository.Exists(model.Email);
            if(studentExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Student Already exist"
                };
            }
            var userExit = await _userRepository.FindUserByEmail(model.Email);
            if(userExit != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " User Already Exist"
                };
            }
            var role = await _roleRepository.FindRoleByName("Student");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = Guid.NewGuid().ToString(),
                PasswordHash = hashedPassword,
                Password = model.Password,
            };
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DepartmentId = model.DepartmentId,
                User = user,
                StudentCode = $"L{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
                UserId = user.Id
            };
            await _userRepository.AddUser(user);
            await _studentRepository.AddStudent(student);
            return new BaseResponse
            {
                Status = true,
                Message = " Student Registered Successfully"
            };
        }

        public async Task<StudentResponseModel> DeleteStudent(int id)
        {
            var student = await _studentRepository.FindStudentById(id); 
            if(student == null)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = " Student does not exist"
                };
            }
            await _studentRepository.DeleteStudent(student);
            return new StudentResponseModel
            {
                Status = true,
                Message = " Student deleted Successfiully"
            };
        }

        public async Task<StudentsResponseModel> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();
            var studentReturned = students.Select(s => new StudentDto
            {
             
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
            }).ToList();
            return new StudentsResponseModel
            {
                Data = studentReturned,
                Status = true,
                Message = "All student retreived successfully"
            };
        }

        public async Task<StudentResponseModel> GetStudentById(int id)
        {
            var student = await _studentRepository.FindStudentById(id);
            if( student == null)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = "No such Studenyt found"
                }; 
            }
            return new StudentResponseModel
            {
                Data = new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    DepartmentId = student.DepartmentId,
                    DepartmentName = student.Department.Name
                },
                Status = true,
                Message = "Student detials retreived successfully"
            };
        }

        public async Task<BaseResponse> UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            var student = await _studentRepository.FindStudentById(id);
            if(student == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No such Student found"
                };
            }
            student.LastName = model.LastName;
            student.Email = model.Email;
            await _studentRepository.UpdateStudent(student);
            return new BaseResponse
            {
                Status = true,
                Message = "Student details Updated Succeffully"
            };
        }
    }
}
