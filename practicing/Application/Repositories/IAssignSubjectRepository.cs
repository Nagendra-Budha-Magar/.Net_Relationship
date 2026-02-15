using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public interface IAssignSubjectRepository
    {
        Task<bool> SubjectExists(int Id);
        Task<bool> SemesterExists(int Id);
        Task AssignSubject(AssignSubject entity);
    }
}
