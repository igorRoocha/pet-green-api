using PetGreen.Domain.Entities.Interfaces;
using PetGreen.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetGreen.Domain.Entities
{
    [Table("CDAddress")]
    public class Address: BaseEntity
    {
        public Address()
        {
            CreatedAt = DateTime.UtcNow;
        }
        private string _Cep;

        public string Cep
        {   get => _Cep;
            set
            {
                _Cep = Utils.RemoveMask(value);
            }
        }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public Guid CityID { get; set; }
        [NotMapped]
        public virtual City City { get; set; }
        [NotMapped]
        public virtual Clinic Clinic { get; set; }
    }
}
