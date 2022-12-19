using HazarVenturesWebApi.Dtos;
using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.Implementations.Repositories;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _lecturerReposictory;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public LecturerService(ILecturerRepository lecturerReposictory, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _lecturerReposictory = lecturerReposictory;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<LecturerResponseModel> DeleteLecturer(int id)
        {
            var lecturer = await _lecturerReposictory.FindLecturerById(id);
            if(lecturer == null)
            {
                return new LecturerResponseModel
                {
                    Status = false,
                    Message = " No such Lecturer exist"
                };
            }
            await _lecturerReposictory.DeleteLecturer(lecturer);
            return new LecturerResponseModel
            {
                Status = true,
                Message = " Lecturer Successfully deleted"
            };
        }

        public async Task<LecturersResponseModel> GetAllLecturer()
        {
            var lectutrers = await _lecturerReposictory.GetAlllecturers();
            return new LecturersResponseModel
            {
                Data = lectutrers.Select(l => new LecturerDto
                {
                    Id = l.Id,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    Email = l.Email

                }).ToList(),
                Status = true,
                Message = "All Lecturer Retreived successfully "
            };
        }

        public async Task<LecturerResponseModel> GetLecturerById(int id)
        {
            var lecturer = await _lecturerReposictory.FindLecturerById(id);
            if(lecturer == null)
            {
                return new LecturerResponseModel
                {
                    Status = false,
                    Message = " No such Lecturer exist"
                };
            }
            return new LecturerResponseModel
            {
                Data = new LecturerDto
                {
                    Id = lecturer.Id,
                    FirstName = lecturer.FirstName,
                    LastName = lecturer.LastName,
                    Email = lecturer.Email,
                    lecturerCode = lecturer.LecturerCode
                    
                },
                Status = true,
                Message = " Lecturer's Details Retreived Successfully"
            };
        }

        public async Task<BaseResponse> RegisterLecturer(RegisterLecturerRequestModel model)
        {
            var userExist = await _userRepository.FindUserByEmail(model.Email);
            if (userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "User Already Exist"
                };
            }
            var lecturerExist = await _lecturerReposictory.Exists(model.Email);
            if(lecturerExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Lecturer already exist"
                };
            }
            var role = await _roleRepository.FindRoleByName("lecturer");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = Guid.NewGuid().ToString(),
                PasswordHash = hashedPassword,
                Password = model.Password
                
            };
            await _userRepository.AddUser(user);
            var lecturer = new Lecturer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DepartmentId = model.DepartmentId,
                User = user,
                LecturerCode = $"L{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
                UserId = user.Id,
            };
            
            await _lecturerReposictory.AddLecturer(lecturer);
            
            return new BaseResponse
            {
                Status = true,
                Message = " Lecturer registered Successfully"

            };

        }

        public async Task<BaseResponse> UpdateLecturer(int id, UpdateLecturerRequestModel model)
        {
            var lecturer = await _lecturerReposictory.FindLecturerById(id);
            if(lecturer == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " No such Lecturer Exist"
                };
            }
            lecturer.LastName = model.LastName;
            lecturer.Email = model.Email;
            await _lecturerReposictory.UpdateLecturer(lecturer);
            return new BaseResponse
            {
                Status = true,
                Message = "Lecturer Updated Successfully"
            };
        }
    }
}
