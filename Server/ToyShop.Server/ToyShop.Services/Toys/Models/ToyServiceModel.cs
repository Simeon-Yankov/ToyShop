using System.Collections.Generic;

namespace ToyShop.Services.Toys.Models
{
    public class ToyServiceModel
    {
        public int Id { get; init; }

        public string Description { get; init; }

        public List<string> ImageUrls { get; init; }
    }
}