using PetGreen.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities
{
    [Table("CDState")]
    public class State: BaseEntity
    {
        public State()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; set; }
        public string UF { get; set; }
        public IReadOnlyCollection<City> Cities { get; private set; }
    }
}
