using System.Collections.Generic;
using System.Threading.Tasks;

using ToyShop.Services.Toys.Models;

namespace ToyShop.Services.Toys.Contracts
{
    public interface IToyService
    {
        Task<int> Create(string userId, string description, List<string> imagesUrls);

        Task<IEnumerable<ToyServiceModel>> ByUser(string userId);
    }
}