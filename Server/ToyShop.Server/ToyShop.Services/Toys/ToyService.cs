using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ToyShop.Data;
using ToyShop.Models;
using ToyShop.Services.Toys.Contracts;
using ToyShop.Services.Toys.Models;

namespace ToyShop.Services.Toys
{
    public class ToyService : IToyService
    {
        private readonly ToyShopDbContext data;

        public ToyService(ToyShopDbContext data)
            => this.data = data;

        public async Task<IEnumerable<ToyServiceModel>> ByUser(string userId)
            => await this.data
                .Toys
                .Where(t => t.UserId == userId)
                .Select(t => new ToyServiceModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    ImageUrls = t
                                    .ImagesUrl
                                    .Select(t => t.Url)
                                    .ToList()
                })
                .ToListAsync();

        public async Task<int> Create(string userId, string description, List<string> imagesUrls)
        {
            var imagesUrl = new List<ImageUrl>();

            PopulateListImagesUrls(imagesUrls, imagesUrl);

            var toy = new Toy
            {
                Description = description,
                ImagesUrl = imagesUrl,
                UserId = userId
            };

            await this.data.Toys.AddAsync(toy);
            await this.data.SaveChangesAsync();

            return toy.Id;
        }

        public async Task<ToyDetailsServiceModel> Details(int id)
            => await this.data
                .Toys
                .Where(t => t.Id == id)
                .Select(t => new ToyDetailsServiceModel
                {
                    Description = t.Description,
                    ImagesUrl = t.ImagesUrl.Select(iu => iu.Url).ToList(),
                    UserId = t.UserId
                })
                .FirstOrDefaultAsync();

        public async Task<bool> Update(int id, string description, ICollection<string> urls, string userId)
        {
            var toy = await this.data
                .Toys
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (toy is null)
            {
                return false;
            }

            toy.Description = description;
            toy.ImagesUrl.Clear();

            foreach (var url in urls)
            {
                toy
                    .ImagesUrl
                    .Add(new ImageUrl
                    {
                        Url = url,
                    });
            }

            await this.data.SaveChangesAsync();

            return true;
        }

        private static void PopulateListImagesUrls(List<string> imagesUrls, List<ImageUrl> listImgsUrls)
        {
            foreach (var imageUrl in imagesUrls)
            {
                var imgUrl = new ImageUrl
                {
                    Url = imageUrl
                };

                listImgsUrls.Add(imgUrl);
            }
        }
    }
}