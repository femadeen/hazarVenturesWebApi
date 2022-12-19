namespace HazarVenturesWebApi.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
    }
}
