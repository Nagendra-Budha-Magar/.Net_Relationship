using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> InsertStudent(Student entity);
        Task<bool> UpdateSemester(int studentId, int semesterId);
        IQueryable<Student> GetAll();
        IQueryable<Student?> GetById(int Id);
        Task<bool> DeleteStudent(int Id);
    }
}
