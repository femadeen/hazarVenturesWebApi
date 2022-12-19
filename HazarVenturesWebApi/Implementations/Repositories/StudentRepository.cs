using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarVenturesWebApi.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HazarVenturesDbContext _context;
        public StudentRepository(HazarVenturesDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            _context.SaveChanges();
            return student;
        }

        public async Task<bool> DeleteStudent(Student student)
        {
             _context.Students.Remove(student);
            return true;
        }

        public async Task<bool> Exists(string email)
        {
            var student = await _context.Students.AnyAsync(s => s.Email.ToLower() == email.ToLower());
            return student;
        }

        public async Task<Student> FindStudentByEmail(string email)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email.ToLower() == email.ToLower());
            return student;
        }

        public async Task<Student> FindStudentById(int id)
        {
            var student = await _context.Students.Include(s => s.Department)
                .SingleOrDefaultAsync(s => s.Id == id);
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<int> GetStudentCount()
        {
            var studentCount = await _context.Students.CountAsync();
            return studentCount;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}
