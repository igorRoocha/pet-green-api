using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities.Register
{
    public class Specie: BaseEntity
    {
        public Specie()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public string Name { get; set; }

        public virtual List<Breed> Breeds { get; private set; }
    }
}
