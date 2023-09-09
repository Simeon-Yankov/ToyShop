using System.ComponentModel.DataAnnotations;

using static ToyShop.Common.GlobalConstants.Toy;

namespace ToyShop.Server.Models.Toy
{
    public class UpdateRequestModel
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }

        public ICollection<string> ImageUrls { get; init; }
    }
}