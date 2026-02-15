using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using practicing.Application.Repositories;
using practicing.Data;
using practicing.Domain.Dtos;
using practicing.Domain.Entity;

namespace practicing.Application.Services
{
    public class AssignSubjectService : IAssignSubjectService
    {
        private readonly IAssignSubjectRepository _repository;

        public AssignSubjectService(IAssignSubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AssignSubject(AssignSubjectDto dto)
        {
            var subjectExist = await _repository.SubjectExists(dto.subjectId);
            var semesterExist = await _repository.SemesterExists(dto.semesterId);

            //  checking if both exist
            if (!subjectExist || !semesterExist)
            {
                return false;
            }

            var link = new AssignSubject
            {
                subjectId = dto.subjectId,
                semesterId = dto.semesterId
            };

            await _repository.AssignSubject(link);
            //_context.AssignSubjects.Add(link);
            //await _context.SaveChangesAsync();

            return true;
        }
    }
}