namespace SignalRServerExample.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using SignalRServer.Interfaces;

    public class MyHub : Hub<IMessageClient>
    {
        private static List<string> clients = new List<string>();

        //public async Task SendMessageAsync(string message)
        //{
        //    //Ekstra islemler
        //    await Clients.All.SendAsync("receiveMessage", message);
        //}

        //Sisteme bir baglanti yapildigi zaman tetiklenecek

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);

            //Server-Client tarafli uygulamalarda metinsel bazli ifadeleri kullanmak hataya sebep verebileceginden, bunlari interface bazli tanimlamak daha sagliklidir ve tavsiye edilir.
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined",Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }


        //Sistemden bir baglanti koptugunda tetiklenecek

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }

    }
}
