using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Application.Services;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectDto dto)
        {
            var result = await _service.AddSubject(dto);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("{Id:int}")]
        //public async Task<IActionResult> GetSubject(int Id)
        //{
        //    var data = await _context.Subjects.FirstOrDefaultAsync();
        //    if(data is null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(data);
        //}


        //[HttpDelete]
        //[Route("{Id:int}")]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var data = await _context.Subjects.FindAsync(Id);
        //    if (data is null)
        //        return NotFound();
        //    _context.Subjects.Remove(data);
        //    await _context.SaveChangesAsync();

        //    return Ok("Deleted Successfully");
        //}
    }
}
