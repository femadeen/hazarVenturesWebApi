namespace HazarVenturesWebApi.Models.RequestModels
{
    public class UpdateStudentRequestModel
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
    }
}
