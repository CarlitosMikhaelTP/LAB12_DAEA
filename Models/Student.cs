﻿namespace APISemana11A.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        // Clave foránea a Grade
        public int GradeID { get; set; }
        public Grade Grade { get; set; }

        // Relación con Enrollment (uno a muchos)
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
