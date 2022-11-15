using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRServer.Controllers
{
    using Business;
    using Microsoft.AspNetCore.SignalR;
    using SignalRServerExample.Hubs;

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myBusiness;
        readonly IHubContext<MyHub> _hubContext; //Eger yapimizda Business-Logic yapisi yok ise dogrudan controller üzerinden DI sayesinde MyHub daki SignalR teknolojisi kullanilabilir.

        public HomeController(MyBusiness myBusiness, IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
            
        }
    }
}
