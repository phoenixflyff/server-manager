using Microsoft.AspNetCore.Mvc;

namespace server_manager.Controllers
{
    public class StateController : Controller
    {
        public class StateOutput
        {
            public bool isOnline { get; set; }
            public int connectedUsers { get; set; }
            public bool isMaintenance { get; set; }
        }

        [Route("")]
        public IActionResult Get()
        {
            return new JsonResult(new StateOutput()
            {
                isOnline = true,
                connectedUsers = 10,
                isMaintenance = false
            });
        }
    }
}
