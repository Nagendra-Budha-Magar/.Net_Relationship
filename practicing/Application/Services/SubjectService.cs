using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<SubjectDto?> GetById(int Id)
        {
            var Result = await _repository.GetById(Id);
            if (Result is null)
                return null;

            var subject = new SubjectDto
            {
                Name = Result.Name,
                Description = Result.Description
            };
            return subject;
        }

        public async Task<SubjectDto?> UpdateSubject(int Id, SubjectDto dto)
        {
            var result = await _repository.GetById(Id);
            if (result is null)
                return null;

            result.Name =string.IsNullOrEmpty(dto.Name) ? result.Name : dto.Name;   // Checks if client send null or empty data if yes than it store the previous data insted is not than data will be updated
            result.Description = string.IsNullOrEmpty(dto.Description) ? result.Description : dto.Description;

            await _repository.UpdateById(result);

            return new SubjectDto
            {
                Name = result.Name,
                Description = result.Description
            };
        }

        public async Task<bool> DeleteById(int Id)
        {
            var result = await _repository.GetById(Id);
            if (result == null)
                return false;

            await _repository.DeleteById(result);
            return true;

        }
    }
}
