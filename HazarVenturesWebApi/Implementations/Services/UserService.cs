using HazarVenturesWebApi.Dtos;
using HazarVenturesWebApi.Implementations.Repositories;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;
using System.Reflection.Metadata.Ecma335;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ILecturerRepository _lecturerReposictory;
        public UserService(IUserRepository userRepository, IStudentRepository studentRepository, ILecturerRepository lecturerReposictory)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _lecturerReposictory = lecturerReposictory;
        }

        public async Task<UserResponseModel> ChangePassword(int id, ChangePasswordRequestModel request)
        {
           var user = await _userRepository.FindUserById(id); 
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = true,
                    Message = "User not exist"
                };
            }
            if(user.Role.Name.ToLower() == "student" || user.Role.Name.ToLower() == "lecturer")
            {
                if(request.OldPassword == user.Password)
                {
                    user.Password = request.NewPassword;
                }
            }
            return new UserResponseModel
            {
                Status = true,
                Message = "Password Updated Sucessfully"
            };
        }

        public async Task<UsersResponseModel> GetAllUSers()
        {
            var users = await _userRepository.GetAllUsers();
            var returnedUsers = users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                RoleId = u.RoleId,
            }).ToList();
            return new UsersResponseModel
            {
                Data = returnedUsers,
                Status = true,
                Message = " All users retireved successfully"
            };
        }
        

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.FindUserById(id);
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = " No such user exist"
                };
            }
            if (user.Role.Name.ToLower() == "student")
            {
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email.ToLower(),
                        FirstName = user.Student.FirstName,
                        LastName = user.Student.LastName,
                        DepartmentName = user.Student.Department.Name,
                        RoleId = user.Role.Id,
                        RoleName = user.Role.Name,
                        StudentId = user.Student.Id,
                    },
                    Status = true,
                    Message = "Student User Retreived Successfully"
                };
            }
            else
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email.ToLower(),
                        FirstName = user.Lecturer.FirstName,
                        LastName = user.Lecturer.LastName,
                        DepartmentName = user.Lecturer.Department.Name,
                        RoleId = user.RoleId,
                        RoleName = user.Role.Name,
                        LecturerId = user.Lecturer.Id
                    },
                    Status = true,
                    Message = "Lectuer User retreived successfully"
                };
        }

        public async Task<UserResponseModel> Login(LoginRequestModel model)
        {
            var user = await _userRepository.FindUserByEmail(model.Email);
            if (user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = " No such user exist"
                };
            };
            var passwordCheck = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
            if (passwordCheck)
            {
                if (user.Role.Name.ToLower() == "student")
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Id = user.Id,
                            StudentId = user.Student.Id,
                            Email = user.Email,
                            FirstName = user.Student.FirstName,
                            LastName = user.Student.LastName,
                            DepartmentName = user.Student.Department.Name,
                            RoleName = user.Role.Name,
                            RoleId = user.RoleId
                        },
                        Status = true,
                        Message = " Student Login Successfully"

                    };
                }
                else
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.Lecturer.FirstName,
                            LastName = user.Lecturer.LastName,
                            DepartmentName = user.Lecturer.Department.Name,
                            RoleName = user.Role.Name,
                            LecturerId = user.Lecturer.Id,
                            RoleId = user.RoleId
                        },
                        Status = true,
                        Message = "Lecturer Loging Successfully"
                    };

                };
            }
            return new UserResponseModel
            {
                Status = false,
                Message = " Email/Password is invalid"
            };

        }
    }
}
