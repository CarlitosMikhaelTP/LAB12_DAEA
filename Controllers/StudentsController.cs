using APISemana11A.Context;
using APISemana11A.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISemana11A.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchooLContext _context;

        public StudentsController(SchooLContext context)
        {
            _context = context;
        }

        // GET: api/Students/GetAll
        [HttpGet]
        public List<Student> GetAll()
        {
            // Solo obtener estudiantes activos
            return _context.Students.Where(s => s.IsActive).ToList();
        }

        // GET: api/Students/GetById/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/Students/Insert
        [HttpPost]
        public IActionResult Insert([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = student.StudentID }, student);
        }

        // PUT: api/Students/Update
        [HttpPut]
        public IActionResult Update([FromBody] Student student)
        {
            var existingStudent = _context.Students.Find(student.StudentID);
            if (existingStudent == null)
                return NotFound();

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Phone = student.Phone;
            existingStudent.Email = student.Email;
            existingStudent.GradeID = student.GradeID;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Students/Delete/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            student.IsActive = false;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
