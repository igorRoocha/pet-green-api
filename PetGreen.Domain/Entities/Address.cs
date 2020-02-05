using PetGreen.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetGreen.Domain.Entities
{
    [Table("CDAddress")]
    public class Address: BaseEntity, IAddress
    {
        public Address()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public string Cep { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
    }
}
