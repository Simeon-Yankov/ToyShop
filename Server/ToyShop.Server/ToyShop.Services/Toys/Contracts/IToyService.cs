using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToyShop.Services.Toys.Contracts
{
    public interface IToyService
    {
        Task<int> Create(string userId, string description, List<string> imagesUrls);
    }
}