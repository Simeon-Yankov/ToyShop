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

        [HttpGet]
        [Route(nameof(Details))]
        public async Task<IActionResult> Details(int id)
        {
            var toyDetails = await this.toyService.Details(id);

            return toyDetails is null ? NotFound() : Ok(toyDetails);
        }

        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IActionResult> Mine()
        {
            var userId = this.User.Id();

            return Ok(await this.toyService.ByUser(userId));
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update(UpdateRequestModel model)
        {
            var userId = this.User.Id();

            var isUpdated = await this.toyService.Update(
                model.Id,
                model.Description,
                model.ImagesUrl,
                userId);

            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}