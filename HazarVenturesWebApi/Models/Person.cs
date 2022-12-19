using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
