using System;

namespace PetGreen.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid ID {get; set;}

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}