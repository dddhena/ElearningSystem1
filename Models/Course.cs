using System.ComponentModel.DataAnnotations;

namespace ElearningSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int InstructorId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
