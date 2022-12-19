using System.Data;

namespace HazarVenturesWebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Student Student { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
