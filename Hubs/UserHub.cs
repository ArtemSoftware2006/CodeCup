using Microsoft.AspNetCore.SignalR;

namespace CodeCup.Hubs
{
    public class UserHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            Console.WriteLine(user);
            Console.WriteLine(message);
        }
        public async Task AddToGroup(string groupName, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Console.WriteLine(username);
            await Clients.Group(groupName).SendAsync("UserAdded", username);
        }
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Receive", message);
        }
        public async Task JoinGroupFromLink(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).SendAsync("UserAdded", Context.User.Identity.Name);
        }
    }
}