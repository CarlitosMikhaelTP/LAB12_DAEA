using APISemana11A.Models;
using Microsoft.EntityFrameworkCore;

namespace APISemana11A.Context
{
    public class SchooLContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurando a mi base de datos
            optionsBuilder.UseSqlServer("Server=LAPTOP-CTorres;Database=APISemana11ADB; Integrated Security=True;Trust Server Certificate=True ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cardinalidad muchos a uno entre Enrollment y Course
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)               
                .WithMany(c => c.Enrollments)       
                .HasForeignKey(e => e.CourseID);

            // Cardinalidad  muchos a uno entre Enrollment y Student
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)          
                .WithMany(s => s.Enrollments)         
                .HasForeignKey(e => e.StudentID);

            // Cardinalidad  uno a muchos entre Grade y Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)                
                .WithMany(g => g.Students)          
                .HasForeignKey(s => s.GradeID);      
        }
    }
}
