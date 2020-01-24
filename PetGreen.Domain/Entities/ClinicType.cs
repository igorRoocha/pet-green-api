using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PetGreen.Entities;

namespace PetGreen.Domain.Entities
{
    [Table("CDClinicType")]
    public class ClinicType : BaseEntity
    {
        public string Description {get; set;}

        public IReadOnlyCollection<Clinic> Clinics { get; private set; }
    }
}