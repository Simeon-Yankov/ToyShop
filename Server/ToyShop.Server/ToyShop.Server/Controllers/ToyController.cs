using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ToyShop.Common.Infrastructure.Services.Users.Contracts;
using ToyShop.Server.Models.Toy;
using ToyShop.Services.Toys.Contracts;

using static ToyShop.Server.Infrastructure.WebConstants;
using static ToyShop.Server.Infrastructure.WebConstants.Toy;

namespace ToyShop.Server.Controllers
{
    public class ToyController : ApiController
    {
        private readonly IToyService toys;
        private readonly ICurrentUserService currentUser;

        public ToyController(IToyService toys, ICurrentUserService currentUser)
        {
            this.toys = toys;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CreateRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var toyId = await toys.Create(userId, model.Description, model.ImageUrls);

            return Created(nameof(this.Create), toyId);
        }

        [HttpGet]
        [Route(nameof(Details))]
        public async Task<IActionResult> Details(int id)
        {
            var toyDetails = await this.toys.Details(id);

            return toyDetails is null ? NotFound() : Ok(toyDetails);
        }

        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IActionResult> Mine()
        {
            var userId = this.currentUser.GetId();

            return Ok(await this.toys.ByUser(userId));
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update(UpdateRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var isUpdated = await this.toys.Update(
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

        [HttpDelete]
        [Route(Id)]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.toys.DeleteHard(id, this.currentUser.GetId());

            if (!isDeleted)
            {
                return BadRequest(NotFoundMessge);
            }

            return Ok();
        }
    }
}