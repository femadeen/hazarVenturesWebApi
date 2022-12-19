using HazarVenturesWebApi.Models;

namespace HazarVenturesWebApi.Entities
{
    public class Lecturer : Person
    {
        public string LecturerCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
