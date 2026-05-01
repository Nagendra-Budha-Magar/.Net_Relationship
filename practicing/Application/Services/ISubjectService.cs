using practicing.Domain.Dtos;

namespace practicing.Application.Services
{
    public interface ISubjectService
    {
        Task<SubjectDto> AddSubject(SubjectDto dto);
        Task<SubjectDto?> GetById(int Id);
        Task<SubjectDto?> UpdateSubject(int Id, SubjectDto dot);
        Task<bool> DeleteById(int Id);
        
    }
}
