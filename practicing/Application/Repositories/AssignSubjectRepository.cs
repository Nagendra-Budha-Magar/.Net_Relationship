using Microsoft.EntityFrameworkCore;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public class AssignSubjectRepository : IAssignSubjectRepository
    {
        private readonly AppDbContext _context;
        public AssignSubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SubjectExists(int Id)
        {
            return await _context.Subjects.AnyAsync(s => s.Id == Id);
        }

        public async Task<bool> SemesterExists(int Id)
        {
            return await _context.Semesters.AnyAsync(s => s.Id == Id);
        }

        public async Task AssignSubject(AssignSubject entity)
        {
            _context.AssignSubjects.Add(entity);
            await _context.SaveChangesAsync();

        }
    }
}
