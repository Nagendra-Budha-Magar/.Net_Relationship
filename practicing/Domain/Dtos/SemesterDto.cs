using practicing.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace practicing.Domain.Dtos
{
    public class SemesterDto
    {
        public required string Name { get; set; }
        public List<SubjectDto>? subjects { get; set; }
    }
}
