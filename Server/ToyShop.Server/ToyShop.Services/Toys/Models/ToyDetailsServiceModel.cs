using System.Collections.Generic;

namespace ToyShop.Services.Toys.Models
{
    public class ToyDetailsServiceModel
    {
        public string Description { get; set; }

        public List<string> ImagesUrl { get; init; }

        public string UserId { get; init; }
    }
}