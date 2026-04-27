using Microsoft.EntityFrameworkCore;
using ElearningSystem.Models;

namespace ElearningSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Clean slate for real-time subsystem
            modelBuilder.Entity<Message>()
                .HasKey(m => m.MessageId);

            // Prevent a student from enrolling in the same course twice
            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();
        }
    }
}
