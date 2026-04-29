using practicing.Application.Repositories;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubjectDto> AddSubject(SubjectDto dto)
        {
            var subject = new Subject
            {
                Name = dto.Name ?? string.Empty,
                Description = dto.Description ?? string.Empty
            };

             await _repository.AddSubject(subject);

            return dto;
        }
    }
}
