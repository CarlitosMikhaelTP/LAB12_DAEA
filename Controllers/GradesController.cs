using APISemana11A.Context;
using APISemana11A.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISemana11A.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly SchooLContext _context;

        public GradesController(SchooLContext context)
        {
            _context = context;
        }

        // GET: api/Grades/GetAll
        [HttpGet]
        public List<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        // GET: api/Grades/GetById/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade == null)
                return NotFound();

            return Ok(grade);
        }

        // POST: api/Grades/Insert
        [HttpPost]
        public IActionResult Insert([FromBody] Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = grade.GradeID }, grade);
        }

        // PUT: api/Grades/Update
        [HttpPut]
        public IActionResult Update([FromBody] Grade grade)
        {
            var existingGrade = _context.Grades.Find(grade.GradeID);
            if (existingGrade == null)
                return NotFound();

            existingGrade.Name = grade.Name;
            existingGrade.Description = grade.Description;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Grades/Delete/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade == null)
                return NotFound();

            _context.Grades.Remove(grade);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
