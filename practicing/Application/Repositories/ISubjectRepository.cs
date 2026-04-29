using practicing.Domain.Entity;

namespace practicing.Application.Repositories
{
    public interface ISubjectRepository
    {
        Task<Subject> AddSubject(Subject entity);
    }
}
