using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToyShop.Server.Controllers
{
    public class HomeController : ApiController
    {
        [AllowAnonymous]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Works");
        }
    }
}