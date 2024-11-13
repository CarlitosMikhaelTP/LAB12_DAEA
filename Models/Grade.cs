namespace APISemana11A.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relación con Student (uno a muchos)
        public ICollection<Student> Students { get; set; }
    }
}
