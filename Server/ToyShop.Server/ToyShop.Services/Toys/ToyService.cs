using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ToyShop.Data;
using ToyShop.Models;
using ToyShop.Server.Models.Toy;
using ToyShop.Services.Toys.Contracts;
using ToyShop.Services.Toys.Models;

namespace ToyShop.Services.Toys
{
    public class ToyService : IToyService
    {
        private readonly ToyShopDbContext data;

        public ToyService(ToyShopDbContext data)
            => this.data = data;

        public async Task<int> Create(string userId, CreateRequestModel model)
        {
            var imagesUrl = new List<ImageUrl>();

            PopulateListImagesUrls(model.ImageUrls, imagesUrl);

            var toy = new Toy
            {
                Description = model.Description,
                ImagesUrl = imagesUrl,
                UserId = userId,
            };

            await this.data.Toys.AddAsync(toy);
            await this.data.SaveChangesAsync();

            return toy.Id;
        }

        public async Task<Result> Update(string userId, UpdateRequestModel model)
        {
            var toy = await GetByIdAndUserId(model.Id, userId);

            if (toy is null)
            {
                return "There is no toy with the given id";
            }

            toy.Description = model.Description;
            toy.ImagesUrl.Clear();

            foreach (var url in model.ImageUrls)
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

        public async Task<ToyDetailsServiceModel> Details(int id)
            => await this.data
                .Toys
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(t => new ToyDetailsServiceModel
                {
                    Description = t.Description,
                    ImagesUrl = t.ImagesUrl.Select(iu => iu.Url).ToList(),
                    UserId = t.UserId
                })
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ToyServiceModel>> ByUser(string userId)
            => await this.data
                .Toys
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedOn)
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

        public async Task<Result> Delete(int id, string userId)
        {
            var toy = await GetByIdAndUserId(id, userId);

            if (toy is null)
            {
                return "There is no toy with the given id";
            }

            this.data.Toys.Remove(toy);

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Toy> GetByIdAndUserId(int id, string userId)
            => await this.data
                .Toys
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);


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