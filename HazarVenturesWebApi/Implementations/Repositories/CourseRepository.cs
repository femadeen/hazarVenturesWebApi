using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarVenturesWebApi.Implementations.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly HazarVenturesDbContext _context;
        public CourseRepository(HazarVenturesDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddCourse(Course course)
        {
            await _context.AddAsync(course);
            _context.SaveChanges();
            return course;


        }

        public async Task<bool> DeleteCourse(Course course)
        {
            _context.Remove(course);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Exist(string courseName)
        {
            var course = await _context.courses.AnyAsync(c => c.CourseName.ToLower() == courseName.ToLower());
            return course;
        }

        public async Task<Course> FindCourseById(int id)
        {
            var course = await _context.courses.SingleOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var courses = await _context.courses.ToListAsync();
            return courses;
        }

        public async Task<List<Course>> GetCoursesByStudent(int studentId)
        {
            var coursesByStudent = await _context.courses.Where(c => c.studentCourses.Any(c => c.StudentId == studentId)).ToListAsync();
            return coursesByStudent;
        }

        public async Task<List<Course>> GetSelectedCourses(List<int> courseIds)
        {
            var selectedCourses = await _context.courses.Where(c => courseIds.Contains(c.Id)).ToListAsync();
            return selectedCourses;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _context.courses.Update(course);
            _context.SaveChanges();
            return course;
        }
    }
}
