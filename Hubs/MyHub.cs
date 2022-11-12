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

        #region Overrides of Hub
        //Sisteme bir baglanti yapildigi zaman tetiklenecek

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        #endregion

        #region Overrides of Hub
        //Sistemden bir baglanti koptugunda tetiklenecek

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        #endregion
    }
}
