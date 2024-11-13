namespace APISemana11A.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public DateTime Date { get; set; }

        // Clave foránea a Student
        public int StudentID { get; set; }
        public Student Student { get; set; }

        // Clave foránea a Course
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
