using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

using ToyShop.Models.Base.Contracts;

namespace ToyShop.Models
{
    public class User : IdentityUser, IEntity
    {
        public User() 
            => this.Toys = new List<Toy>();

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public ICollection<Toy> Toys { get; init; }
    }
}