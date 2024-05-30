using Core.Repositories.CommonInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ObsEntities
{
    public class StudentCourse : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StudentId")]
        [Required(ErrorMessage = "This is required!")]
        public int StudentId { get; set; }
        [ForeignKey("CourseId")]
        [Required(ErrorMessage = "This is required!")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "This is required!")]
        [Range(1999,2030)]
        public int Year { get; set; }
        [Required(ErrorMessage = "This is required!")]
        public string? Semester { get; set; }
    }
}
