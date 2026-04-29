using practicing.Domain.Dtos;

namespace practicing.Application.Services
{
    public interface ISubjectService
    {
        Task<SubjectDto> AddSubject(SubjectDto dto);
    }
}
