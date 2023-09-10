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
        public async Task CreateGroup()
        {
            string groupName = Guid.NewGuid().ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("CreateGroup", groupName);
        }
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Receive", message);
        }
        public async Task JoinGroupFromLink(string username, string group)
        {
            Console.WriteLine(group);
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            Console.WriteLine(username);
            await Clients.Group(group).SendAsync("UserAdded", username);
        }
    }
}