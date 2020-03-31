using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetGreen.Domain.Entities.Register
{
    public class Breed : BaseEntity
    {
        public Breed()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; set; }

        public Guid SpecieID { get; set; }

        [ForeignKey("SpecieID")]
        public virtual Specie Specie { get; set; }
    }
}
