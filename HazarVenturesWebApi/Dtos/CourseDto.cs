using HazarVenturesWebApi.Entities;

namespace HazarVenturesWebApi.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string courseName { get; set; }
        public string description { get; set; }
        public List<StudentDto> students { get; set; } = new List<StudentDto>();
    }
}
