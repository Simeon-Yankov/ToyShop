using System.ComponentModel.DataAnnotations;

using static ToyShop.Common.GlobalConstants.Toy;

namespace ToyShop.Server.Models.Toy
{
    public class CreateRequestModel
    {
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; init; }

        public List<string> ImageUrls { get; init; }
    }
}