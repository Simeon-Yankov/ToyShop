using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ToyShop.Models
{
    public class User : IdentityUser
    {
        public User() 
            => this.Toys = new List<Toy>();

        public ICollection<Toy> Toys { get; init; }
    }
}