namespace TestAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<StudentCourse>? StudentCourse { get; set;}
    }
}
