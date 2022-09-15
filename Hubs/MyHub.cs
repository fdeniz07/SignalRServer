namespace SignalRServerExample.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class MyHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            //Ekstra islemler
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
