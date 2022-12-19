namespace HazarVenturesWebApi.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
        public List<LecturerDto> Lecturers { get; set; } = new List<LecturerDto>();
    }
}
