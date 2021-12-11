using System.ComponentModel.DataAnnotations;

namespace ToyShop.Models
{
    public class ImageUrl
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string Url { get; set; }

        public int ToyId { get; init; }

        public Toy Toy { get; init; }
    }
}