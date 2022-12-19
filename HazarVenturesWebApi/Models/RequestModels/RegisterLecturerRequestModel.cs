namespace HazarVenturesWebApi.Models.RequestModels
{
    public class RegisterLecturerRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
    }
}
