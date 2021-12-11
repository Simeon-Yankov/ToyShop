using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ToyShop.Server.Infrastructure.Extensions;
using ToyShop.Server.Models.Toy;
using ToyShop.Services.Toys.Contracts;

namespace ToyShop.Server.Controllers
{
    public class ToyController : ApiController
    {
        private readonly IToyService toyService;

        public ToyController(IToyService toyService) 
            => this.toyService = toyService;

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CreateRequestModel model)
        {
            var userId = this.User.Id();

            var toyId = await toyService.Create(userId, model.Description, model.ImageUrls);

            return Created(nameof(this.Create), toyId);
        }
    }
}