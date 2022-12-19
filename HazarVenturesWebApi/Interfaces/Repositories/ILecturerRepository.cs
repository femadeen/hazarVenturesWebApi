using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Interfaces.Repositories
{
    public interface ILecturerRepository
    {
        Task<Lecturer> AddLecturer(Lecturer lecturer);
        Task<Lecturer> FindLecturerById(int id);
        Task<bool> DeleteLecturer(Lecturer lecturer);
        Task<Lecturer> UpdateLecturer(Lecturer lecturer);
        Task<List<Lecturer>> GetAlllecturers();
        Task<bool> Exists(string email);
        Task<int> GetLecturerCount();
    }
}
