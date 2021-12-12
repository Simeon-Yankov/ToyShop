using System.Collections.Generic;
using System.Threading.Tasks;

using ToyShop.Services.Toys.Models;

namespace ToyShop.Services.Toys.Contracts
{
    public interface IToyService
    {
        Task<IEnumerable<ToyServiceModel>> ByUser(string userId);

        Task<int> Create(string userId, string description, List<string> imagesUrls);

        Task<bool> DeleteHard(int id, string userId);

        Task<ToyDetailsServiceModel> Details(int id);

        Task<bool> Update(int id, string description, ICollection<string> urls, string userId);
    }
}