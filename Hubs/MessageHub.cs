namespace SignalRServer.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message)
        {
            Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
