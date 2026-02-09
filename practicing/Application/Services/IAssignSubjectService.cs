using practicing.Domain.Dtos;

namespace practicing.Application.Services
{
    public interface IAssignSubjectService
    {
        Task<bool> AssignSubject(AssignSubjectDto dto);
    }
}
