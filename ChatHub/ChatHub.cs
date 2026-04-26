using Microsoft.AspNetCore.SignalR;
using ElearningSystem.Data;
using ElearningSystem.Models;

namespace ElearningSystem.ChatHubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string courseId, string content)
        {
            var userName = Context.User?.Identity?.Name ?? "Guest";
            
            // Create and save message
            var message = new Message
            {
                Content = content,
                CourseId = int.TryParse(courseId, out int cid) ? cid : 0,
                SenderId = 0, // In a real app, this would be the actual UserID
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            // Broadcast to the course group (and caller)
            await Clients.Group(courseId).SendAsync("ReceiveMessage", userName, content, message.Timestamp.ToString("HH:mm"));
        }

        public async Task JoinCourseGroup(string courseId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, courseId);
        }
    }
}

