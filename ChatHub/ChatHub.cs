using Microsoft.AspNetCore.SignalR;

namespace ElearningSystem.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string courseId, string content)
        {
            // Empty method for now
            await Task.CompletedTask;
        }

        public async Task JoinCourseGroup(string courseId)
        {
            // Empty method for now
            await Task.CompletedTask;
        }
    }
}
