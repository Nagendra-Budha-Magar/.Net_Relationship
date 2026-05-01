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

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetSubject(int Id)
        {
            var result = await _service.GetById(Id);
            if (result is null)
                return NotFound($"Subjwct with {Id} not Found");
            return Ok(result);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateSubject(int Id, SubjectDto dto)
        {
            var result = await _service.UpdateSubject(Id, dto);
            if (result is null)
                return NotFound($"Subject with {Id} not found");

            return Ok(result);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteById(int Id)
        {
            await _service.GetById(Id);
            await _service.DeleteById(Id);
            return Ok("Subject successfully deleted");
        }
    }
}
