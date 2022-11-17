namespace SignalRServer.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class MessageHub : Hub
    {
        // public async Task SendMessageAsync(string message,IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message,string groupName)
        {
            #region Caller

            //Sadece servere bildirimi gönderen client ile iletisim kurar
            //await Clients.Caller.SendAsync("receiveMessage", message);

            #endregion
            #region All

            //Servere bagli olan tüm client ler ile iletisim kurar
            //await Clients.All.SendAsync("receiveMessage", message);

            #endregion
            #region Other

            //Sadece server'a bildirim gönderen client disinda Server'a bagli olan tüm cleint'lara mesaj gönderir.
            //await Clients.Others.SendAsync("receiveMessage", message);

            #endregion


            #region Hub Clients Metotlari

            #region AllExcept

            //Belirtilen Client'lar haric server'a bagli olan tüm client'lara bildiride bulunur.

            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage",message);

            #endregion
            #region Client

            //Server'A bagli olan client'lar arasindan sadece belirli bir client'a bildiride bulunur.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);

            #endregion

            #region Clients

            //Server'a bagli olan client'lar arasindan sadece belirtilenlere bildiride bulunur.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region Group
            //Belirtilen gruptaki tüm clientlara bildiride bulunur.
            //Önce gruplar olusturulmali ve ardindan clientlar gruplara abone olmali


            #endregion

            #region GroupExcept



            #endregion

            #region Groups



            #endregion

            #region OthersInGroup



            #endregion

            #region User



            #endregion

            #region Users



            #endregion

            #endregion

        }


        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
           await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
