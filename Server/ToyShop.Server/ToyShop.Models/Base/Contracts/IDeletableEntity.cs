using System;

namespace ToyShop.Models.Base.Contracts
{
    public interface IDeletableEntity
    {
        DateTime? DeletedOn { get; set; }

        string DeletedBy { get; set; }

        bool IsDeleted { get; set; }
    }
}