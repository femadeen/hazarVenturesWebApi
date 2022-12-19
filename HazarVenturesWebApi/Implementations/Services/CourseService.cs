using HazarVenturesWebApi.Dtos;
using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<CourseResponseModel> DeleteCourse(int id)
        {
            var course = await _courseRepository.FindCourseById(id);
            if(course == null)
            {
                return new CourseResponseModel
                {
                    Status = false,
                    Message = $"The course Id {id} does not exist"
                };
            }
            await _courseRepository.DeleteCourse(course);
            return new CourseResponseModel
            {
                Status = true,
                Message = " Course Successfully deleted"
            };
        }

        public async Task<CoursesResponseModel> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            var selectedCourses = courses.Select(c => new CourseDto
            {
                Id = c.Id,
                courseName = c.CourseName,
                description = c.CourseDsecription,
            }).ToList();
            return new CoursesResponseModel
            {
                Data = selectedCourses,
                Status = true,
                Message = "Couses retreived sucessfully"
            };

        }

        public async Task<CourseResponseModel> GetCourseById(int id)
        {
            var course = await _courseRepository.FindCourseById(id);
            if(course == null)
            {
                return new CourseResponseModel
                {
                    Status = false,
                    Message = $"No such cousre with course id {id} exist"
                };
            }
            return new CourseResponseModel
            {
                Data = new CourseDto
                {
                    Id = course.Id,
                    courseName = course.CourseName,
                    description = course.CourseDsecription,
                    students = course.studentCourses.Select(c => new StudentDto
                    {
                        Id = c.Student.Id,
                        FirstName = c.Student.FirstName,
                        LastName = c.Student.LastName,
                        DepartmentName = c.Student.Department.Name

                    }).ToList(),
                   
                },
                Status = true,
                Message = " Course Successfully retrieved"
            };
        }

        public async Task<BaseResponse> RegisterCourse(RegisterCourseRequestModel model)
        {
            var courseExist = await _courseRepository.Exist(model.Name);
            if( courseExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Course Already Exist"
                };
            }
            var course = new Course
            {
                CourseName = model.Name,
                CourseDsecription = model.Description,
            };
            await  _courseRepository.AddCourse(course);
            return new BaseResponse
            {
                Status = true,
                Message = "Course Registered Successfully"
            };
        }

        public async Task<BaseResponse> UpdateCourse(int id, UpdateCourseRequestModel model)
        {
            var course = await _courseRepository.FindCourseById(id);
            if (course == null)
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "No such course exist"
                };
            }
            course.CourseName = model.Name;
            course.CourseDsecription = model.Description;
            await _courseRepository.UpdateCourse(course);
            return new BaseResponse
            {
                Status = true,
                Message = " Course Successfully Updated"
            };
        }
    }
}
