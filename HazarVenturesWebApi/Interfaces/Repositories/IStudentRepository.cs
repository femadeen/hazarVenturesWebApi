using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> AddStudent(Student student);
        Task<Student> FindStudentById(int id); 
        Task<Student> FindStudentByEmail(string email);
        Task<bool> DeleteStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<List<Student>> GetAllStudents();
        Task<bool> Exists(string email);
        Task<int> GetStudentCount();
    }
}
