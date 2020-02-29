using PetGreen.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities
{
    [Table("CDCity")]
    public class City: BaseEntity
    {
        public City()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; set; }
        public string IBGE { get; set; }
        public Guid StateID { get; set; }
        public IReadOnlyCollection<Address> Addresses { get; private set; }
        public virtual State State { get; set; }
    }
}
