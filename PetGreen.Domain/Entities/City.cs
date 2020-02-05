using PetGreen.Domain.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities
{
    [Table("CDCity")]
    public class City: BaseEntity, ICity
    {
        public string Name { get; set; }
        public string IBGE { get; set; }
        public IReadOnlyCollection<Address> Addresses { get; private set; }
        public State State { get; set; }
    }
}
