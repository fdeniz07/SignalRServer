namespace SignalRServerExample.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class MyHub : Hub
    {
        private static List<string> clients = new List<string>();

        public async Task SendMessageAsync(string message)
        {
            //Ekstra islemler
            await Clients.All.SendAsync("receiveMessage", message);
        }

        //Sisteme bir baglanti yapildigi zaman tetiklenecek

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined",Context.ConnectionId);

        }


        //Sistemden bir baglanti koptugunda tetiklenecek

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }

    }
}
