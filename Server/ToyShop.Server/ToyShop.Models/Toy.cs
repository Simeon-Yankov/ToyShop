using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static ToyShop.Common.GlobalConstants.Toy;

namespace ToyShop.Models
{
    public class Toy
    {
        public Toy() 
            => this.ImagesUrl = new List<ImageUrl>();

        public int Id { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<ImageUrl> ImagesUrl { get; init; }

        [Required]
        public string UserId { get; init; }

        public User User { get; init; }
    }
}