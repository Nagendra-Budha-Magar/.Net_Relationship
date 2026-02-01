using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Data;
using practicing.Dtos;
using practicing.Entity;
using System.Net.WebSockets;

namespace practicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentDto dto)
        {
            var SInfo = new Student
            {
                Name = dto.Name,
                semesterId = dto.semesterId
            };
            _context.Students.Add(SInfo);
            await _context.SaveChangesAsync();
            return Ok("Added Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var result = await _context.Students.ToListAsync();
            //var data = await _context.Students
            //    .Select(s => new StudentDto
            //    {
            //        Name = s.Name,
            //        semesterId = s.semesterId,
            //    })
            //    .ToListAsync();

            //if (!data.Any())
            //    return NotFound();
            

            return Ok(result);
        }


        //[HttpGet]
        //[Route("{Id:int}")]

        //public async Task<IActionResult> GetInfoById(int Id)
        //{
        //    var SInfo = await _context.Students.Include(x => x.semester)
        //        .FirstOrDefaultAsync();
        //    if (SInfo is null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(SInfo);
        //}
        //[HttpGet("{Id:int}")]
        //public async Task<IActionResult> GetInfoById(int Id)
        //{
        //    var SInfo = await _context.Students
        //        .Where(s => s.Id == Id)
        //        .Select(s => new
        //        {
        //            s.Name,
        //            Semesters = s.semester
        //        }
        //        .FirstOrDefaultAsync();

        //    if (SInfo is null)
        //        return NotFound();

        //    return Ok(SInfo);
        //}


        [HttpDelete]
        [Route("{Id:int}")]

        public async Task<IActionResult> Delete(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student is null)
                return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}
