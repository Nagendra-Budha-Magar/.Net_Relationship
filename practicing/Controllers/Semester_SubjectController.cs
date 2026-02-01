using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Data;
using practicing.Dtos;
using practicing.Entity;

namespace practicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Semester_SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        public Semester_SubjectController(AppDbContext DbContext)
        {
            _context = DbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Semester_SubjectDto dto)
        {
            // Check if both exist
            var semesterExists = await _context.Semesters.AnyAsync(s => s.Id == dto.semesterId);
            var subjectExists = await _context.Subjects.AnyAsync(s => s.Id == dto.subjectId);

            if (!semesterExists || !subjectExists)
            {
                return BadRequest("Invalid Semester or Subject ID.");
            }
            var link = new Semester_Subject
            {
                semesterId = dto.semesterId,
                subjectId = dto.subjectId
            };
            _context.Semester_Subjects.Add(link);
            await _context.SaveChangesAsync();
            return Ok("Link Successfully");

        }
    }
}
