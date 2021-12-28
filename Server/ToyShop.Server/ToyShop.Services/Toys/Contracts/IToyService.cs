using System.Collections.Generic;
using System.Threading.Tasks;

using ToyShop.Services.Toys.Models;

namespace ToyShop.Services.Toys.Contracts
{
    public interface IToyService
    {
        Task<int> Create(string userId, string description, List<string> imagesUrls);

        Task<ToyDetailsServiceModel> Details(int id);

        Task<IEnumerable<ToyServiceModel>> ByUser(string userId);

        Task<Result> Update(int id, string description, ICollection<string> urls, string userId);

        Task<Result> Delete(int id, string userId);
    }
}