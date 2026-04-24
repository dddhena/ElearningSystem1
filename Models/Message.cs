using System.ComponentModel.DataAnnotations;

namespace ElearningSystem.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
