using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ToyShop.Models;
using ToyShop.Server.Models.Identity;
using ToyShop.Services.Identity.Contracts;
using ToyShop.Services.Monitoring.Coontracts;
using ToyShop.Services.Monitoring.Models;

namespace ToyShop.Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly AppSettings appSettings;
        private readonly UserManager<User> userManager;
        private readonly IMonitoringProducerService monitoringProducerService;

        public IdentityController(
            IIdentityService identity,
            IOptions<AppSettings> appSettings,
            UserManager<User> userManager,
            IMonitoringProducerService monitoringProducerService)
        {
            this.identity = identity;
            this.appSettings = appSettings.Value;
            this.userManager = userManager;
            this.monitoringProducerService = monitoringProducerService;
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
                var logMessage = $"User with Email '{user.Email}' has registrated.";
                await monitoringProducerService
                        .ProduceAsync(new MonitoringModels.LogModel(DateTime.Now.ToString(), logMessage));

                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user is null)
            {
                return Unauthorized();
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                var logMessage = $"User with Email '{user.Email}' has logged.";
                await monitoringProducerService
                        .ProduceAsync(new MonitoringModels.LogModel(DateTime.Now.ToString(), logMessage));

                return Unauthorized();
            }

            var token = this.identity.GenerateJwtToken(user.Id, model.UserName, this.appSettings.Secret);

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}