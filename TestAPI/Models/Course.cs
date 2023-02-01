namespace TestAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Student> Student { get; set;}
    }
}
