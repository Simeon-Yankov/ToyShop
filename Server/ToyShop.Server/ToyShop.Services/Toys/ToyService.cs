using System.Collections.Generic;
using System.Threading.Tasks;

using ToyShop.Data;
using ToyShop.Models;
using ToyShop.Services.Toys.Contracts;

namespace ToyShop.Services.Toys
{
    public class ToyService : IToyService
    {
        private readonly ToyShopDbContext data;

        public ToyService(ToyShopDbContext data)
            => this.data = data;

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