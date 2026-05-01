using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public interface ISubjectRepository
    {
        Task<Subject> AddSubject(Subject entity);
        Task<Subject?> GetById(int Id);
        Task UpdateById(Subject subject);
        Task DeleteById(Subject subject);
    }
}
