using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<StudentDto> InsertStudent(StudentDto dto)
        {
            var SInfo = new Student
            {
                Name = dto.Name,
                semesterId = dto.semesterId
            };
            _context.Students.Add(SInfo);
            await _context.SaveChangesAsync();

            var result = new StudentDto
            {
                Name = SInfo.Name,
                semesterId = SInfo.semesterId
            };
            return result;
        }
        public async Task<bool> LinkSemester(int studentId, int semesterId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var semester = await _context.Semesters.FindAsync(semesterId);

            if (student == null || semester == null)
            {
                return false;
            }
            student.semester = semester;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<StudentDtoRead>> GetAllAsync()
        {
            var result = await _context.Students
                .Include(s => s.semester)
                .ThenInclude(j => j.join)
                .ThenInclude(s => s.subject)
                .Select(s => new StudentDtoRead
                {
                    Name = s.Name,
                    Semester = s.semester == null ? null : new SemesterDto
                    {
                        Name = s.semester.Name,
                        subjects = s.semester.join.Select(j => new SubjectDto
                    {
                        Name = j.subject.Name,
                        Description = j.subject.Description
                    }).ToList()
                    }
                })
            .ToListAsync();

            return result;
        }

        public async Task<StudentDtoRead> GetStudentById(int Id)
        {
            var student = await _context.Students
                .Where(s => s.Id ==Id)
                .Select(s => new StudentDtoRead
                {
                    Name = s.Name,
                    Semester = s.semester == null ? null : new SemesterDto
                    {
                        Name = s.semester.Name,
                        subjects = s.semester.join.Select(j => new SubjectDto
                        {
                            Name = j.subject.Name,
                            Description = j.subject.Description
                        }).ToList()
                    }
                }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student is null)
                return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
