using HazarVenturesWebApi.Models;

namespace HazarVenturesWebApi.Entities
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<StudentCourse> studentCourses { get; set; } = new List<StudentCourse>();
    }
}
