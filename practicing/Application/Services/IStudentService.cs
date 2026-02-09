using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Services
{
    public interface IStudentService
    {
        Task<StudentDto> InsertStudent(StudentDto dto);
        Task<bool> LinkSemester(int studentId, int semesterId);
        Task<List<StudentDtoRead>> GetAllAsync();
        Task<StudentDtoRead> GetStudentById(int Id);
        Task<bool> DeleteStudent(int Id);
    }
}
