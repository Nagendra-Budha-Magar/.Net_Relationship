using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Application.Services;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;
using System.Net.WebSockets;

namespace practicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentDto dto)
        {
            var SInfo = await _studentService.InsertStudent(dto);

            return Ok(SInfo);
        }

        [HttpPost("Link_Semester")]
        public async Task<IActionResult> LinkSemester(int studentId, int semesterId)
        {
            var result = await _studentService.LinkSemester(studentId, semesterId);

            if (!result)
            {
                return NotFound("Student or Semester not Found!");
            }

            return Ok("Student assigned to Semester successfully");
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var result = await _studentService.GetAllAsync();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetStudentByid(int Id)
        {
            var student = await _studentService.GetStudentById(Id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        //[HttpDelete]
        //[Route("{Id:int}")]

        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var student = await _context.Students.FindAsync(Id);
        //    if (student is null)
        //        return NotFound();
        //    _context.Students.Remove(student);
        //    await _context.SaveChangesAsync();

        //    return Ok("Deleted Successfully");
        //}

        [HttpDelete]
        [Route("{Id:int}")]

        public async Task<IActionResult> Delete(int Id)
        {
            var student = await _studentService.DeleteStudent(Id);

            if (!student)
                return NotFound();

            return Ok("Student has been deleted");
        }
    }
}
