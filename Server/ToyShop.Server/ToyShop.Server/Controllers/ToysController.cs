using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ToyShop.Common.Infrastructure.Services.Users.Contracts;
using ToyShop.Server.Models.Toy;
using ToyShop.Services.Toys.Contracts;

using static ToyShop.Server.Infrastructure.WebConstants;

namespace ToyShop.Server.Controllers
{
    public class ToysController : ApiController
    {
        private readonly IToyService toys;
        private readonly ICurrentUserService currentUser;

        public ToysController(IToyService toys, ICurrentUserService currentUser)
        {
            this.toys = toys;
            this.currentUser = currentUser;
        }

        #region Get
        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IActionResult> Mine()
        {
            var userId = this.currentUser.GetId();

            return Ok(await this.toys.ByUser(userId));
        }

        [HttpGet]
        [Route($"{Id}/{nameof(Details)}")]
        public async Task<IActionResult> Details(int id)
        {
            var toyDetails = await this.toys.Details(id);

            return toyDetails is null ? NotFound() : Ok(toyDetails);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var toyId = await toys.Create(userId, model);

            return Created(nameof(this.Create), toyId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.toys.Update(userId, model);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.toys.Delete(id, this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}