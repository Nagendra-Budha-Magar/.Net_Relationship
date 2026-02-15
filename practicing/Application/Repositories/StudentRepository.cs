using Microsoft.EntityFrameworkCore;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> InsertStudent(Student entity)
        {
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //public async Task<Student?> StudentExists(int Id)
        //{
        //    return await _context.Students.FindAsync(Id);
        //}

        //public async Task<Semester?> SemesterExists(int Id)
        //{
        //    return await _context.Semesters.FindAsync(Id);
        //}

        public async Task<bool> UpdateSemester(int studentId, int semesterId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return false;

            var semester = await _context.Semesters.AnyAsync(s => s.Id == semesterId);
            if (!semester)
                return false;

            student.semesterId = semesterId;
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Student> GetAll()
        {
            return _context.Students;
        }

        public IQueryable<Student?> GetById(int Id)
        {
            return _context.Students
                .Where(s => s.Id == Id);
        }

        public async Task<bool> DeleteStudent(int Id)
        {

            var student = await _context.Students.FindAsync(Id);
            if (student == null)
                return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}