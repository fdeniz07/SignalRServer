namespace SignalRServer.Business
{
    using Microsoft.AspNetCore.SignalR;
    using SignalRServerExample.Hubs;

    public class MyBusiness
    {
       readonly IHubContext<MyHub> _hubContext;

       public MyBusiness(IHubContext<MyHub> hubContext)
       {
           _hubContext = hubContext;
       }

       public async Task SendMessageAsync(string message)
       {
           //Ekstra islemler
           await _hubContext.Clients.All.SendAsync("receiveMessage", message);
       }
    }
}
