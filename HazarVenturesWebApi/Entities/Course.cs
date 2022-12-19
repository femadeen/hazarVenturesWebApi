namespace HazarVenturesWebApi.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDsecription { get; set; }
        public List<StudentCourse> studentCourses { get; set; } = new List<StudentCourse>();

    }
}
