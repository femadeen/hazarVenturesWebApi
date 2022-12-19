namespace HazarVenturesWebApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public int RoleId { get; set; }
        public int StudentId { get; set; }
        public int LecturerId { get; set; }
        public string RoleName { get; set; }

    }
}
