using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TradeArt.TestAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult OnError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "An error occured while executing the API method. Please try again later" });
        }
    }
}
