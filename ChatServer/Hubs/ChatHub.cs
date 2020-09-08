using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "myGroup");
            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(connectionId: Context.ConnectionId, "myGroup");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            //   await Clients.All.ReceiveMessage(message);
            await Clients.Groups("myGroup").ReceiveMessage(message);

        }

    }
}