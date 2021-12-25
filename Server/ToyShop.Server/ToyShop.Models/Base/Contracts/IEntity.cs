using System;

namespace ToyShop.Models.Base.Contracts
{
    public interface IEntity
    {
         DateTime CreatedOn { get; set; }

         string CreatedBy { get; set; }

         DateTime? ModifiedOn { get; set; }

         string ModifiedBy { get; set; }
    }
}