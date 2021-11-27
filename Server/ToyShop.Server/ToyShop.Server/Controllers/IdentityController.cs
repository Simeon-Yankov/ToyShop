using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ToyShop.Models;
using ToyShop.Server.Models.Identity;
using ToyShop.Services.Identity.Contracts;

namespace ToyShop.Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly AppSettings appSettings;
        private readonly UserManager<User> userManager;

        public IdentityController(
            IIdentityService identity,
            IOptions<AppSettings> appSettings,
            UserManager<User> userManager)
        {
            this.identity = identity;
            this.appSettings = appSettings.Value;
            this.userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<string>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user is null)
            {
                return Unauthorized();
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return Unauthorized();
            }

            var token = this.identity.GenerateJwtToken(user.Id, model.UserName, this.appSettings.Secret);

            return token;
        }
    }
}