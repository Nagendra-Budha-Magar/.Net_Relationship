using System.ComponentModel.DataAnnotations.Schema;

namespace practicing.Dtos
{
    public class StudentDto
    {
        public required string Name { get; set; }
        public int? semesterId { get; set; }
    }
}
