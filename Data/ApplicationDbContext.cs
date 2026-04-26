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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Clean slate for real-time subsystem
            modelBuilder.Entity<Message>()
                .HasKey(m => m.MessageId);
        }
    }
}
