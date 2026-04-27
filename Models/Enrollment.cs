using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningSystem.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("StudentId")]
        public User? Student { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
    }
}
