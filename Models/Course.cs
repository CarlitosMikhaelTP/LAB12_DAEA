namespace APISemana11A.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        // Relación con Enrollment (uno a muchos)
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
