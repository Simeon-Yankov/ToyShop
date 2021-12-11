using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToyShop.Server.Controllers
{
    public class HomeController : ApiController
    {
        [AllowAnonymous]
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Works");
        }
    }
}