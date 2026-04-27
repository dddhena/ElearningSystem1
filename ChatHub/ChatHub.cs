using Microsoft.AspNetCore.SignalR;

namespace ElearningSystem.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string courseId, string content)
        {
            var user = Context.User?.Identity?.Name ?? "Anonymous";
            await Clients.All.SendAsync("ReceiveMessage", user, content);
        }

        public async Task JoinCourseGroup(string courseId)
        {
            // Empty method for now
            await Task.CompletedTask;
        }
    }
}
