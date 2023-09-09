using System.Collections.Generic;
using System.Threading.Tasks;
using ToyShop.Server.Models.Toy;
using ToyShop.Services.Toys.Models;

namespace ToyShop.Services.Toys.Contracts
{
    public interface IToyService
    {
        Task<int> Create(string userId, CreateRequestModel model);

        Task<ToyDetailsServiceModel> Details(int id);

        Task<IEnumerable<ToyServiceModel>> ByUser(string userId);

        Task<Result> Update(string userId, UpdateRequestModel model);

        Task<Result> Delete(int id, string userId);
    }
}