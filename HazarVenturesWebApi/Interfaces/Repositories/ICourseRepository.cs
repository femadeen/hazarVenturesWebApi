using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Interfaces.Repositories
{
    public interface  ICourseRepository
    {
        Task<Course> AddCourse(Course course);
        Task<Course> FindCourseById(int id);
        Task<bool> DeleteCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<List<Course>> GetAllCourses();
        Task<List<Course>> GetCoursesByStudent(int studentId);
        Task<List<Course>> GetSelectedCourses(List<int> courseIds);
        Task<bool> Exist(string courseName);
    }
}
