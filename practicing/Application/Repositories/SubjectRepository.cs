using Microsoft.AspNetCore.Http.HttpResults;
using practicing.Data;
using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository( AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> AddSubject(Subject entity)
        {
             _context.Subjects.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Subject> GetById(int Id)
        {
            return  await _context.Subjects.FindAsync(Id);

        }
    }
}
