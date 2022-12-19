using HazarVenturesWebApi.Entities;
using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarVenturesWebApi.Implementations.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly HazarVenturesDbContext _context;
        public LecturerRepository(HazarVenturesDbContext context)
        {
            _context = context;
        }

        public async Task<Lecturer> AddLecturer(Lecturer lecturer)
        {
            await _context.Lecturers.AddAsync(lecturer);
            _context.SaveChanges();
            return lecturer;
        }

        public async Task<bool> DeleteLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Remove(lecturer);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Exists(string email)
        {
            var lecturer = await _context.Lecturers.AnyAsync(l => l.Email.ToLower() == email.ToLower());
            return lecturer ;
        }


        public async Task<Lecturer> FindLecturerById(int id)
        {
            var lecturer = await _context.Lecturers.SingleOrDefaultAsync(l => l.Id == id);
            return lecturer;
        }

        public async Task<List<Lecturer>> GetAlllecturers()
        {
            var lecturers = await _context.Lecturers.ToListAsync();
            _context.SaveChanges();
            return lecturers;
        }

        public async Task<int> GetLecturerCount()
        {
            var lecturerCount = await _context.Lecturers.CountAsync();
            return lecturerCount;
        }

        public async Task<Lecturer> UpdateLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Update(lecturer);
            _context.SaveChanges();
            return lecturer;
        }
    }
}
