using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Application.Repositories;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentDto> InsertStudent(StudentDto dto)
        {
            var SInfo = new Student
            {
                Name = dto.Name,
                semesterId = dto.semesterId
            };
            await _repository.InsertStudent(SInfo);
            //_context.Students.Add(SInfo);
            //await _context.SaveChangesAsync();

            var result = new StudentDto
            {
                Name = SInfo.Name,
                semesterId = SInfo.semesterId
            };
            return result;
        }
        public async Task<bool> LinkSemester(int studentId, int semesterId)
        {
            await _repository.UpdateSemester(studentId,semesterId);         

            return true;
        }

        public async Task<IEnumerable<StudentDtoRead>> GetAllAsync()
        {
            var result = await _repository.GetAll()
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

        public async Task<StudentDtoRead?> GetStudentById(int Id)
        {
            var student = await _repository.GetById(Id)
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
                }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            return await _repository.DeleteStudent(Id);

        }
    }
}
