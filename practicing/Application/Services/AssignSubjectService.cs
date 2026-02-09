using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Services
{
    public class AssignSubjectService : IAssignSubjectService
    {
        private readonly AppDbContext _context;

        public AssignSubjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignSubject(AssignSubjectDto dto)
        {
            var subjectExit = await _context.Subjects.AnyAsync(s => s.Id == dto.subjectId);
            var semesterExit = await _context.Semesters.AnyAsync(s => s.Id == dto.semesterId);

            //  checking if both exist
            if (!subjectExit || !semesterExit)
            {
                return false;
            }

            var link = new AssignSubject
            {
                subjectId = dto.subjectId,
                semesterId = dto.semesterId
            };
            _context.AssignSubjects.Add(link);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
