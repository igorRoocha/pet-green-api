using PetGreen.Domain.Entities.Interfaces;
using PetGreen.Domain.Entities.Register;
using PetGreen.Domain.Models;
using PetGreen.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities
{
    [Table("CDContact")]
    public class Contact : BaseEntity, IContact
    {
        public Contact()
        {
            CreatedAt = DateTime.UtcNow;
        }

        private string _Number;

        public string Number
        {
            get => _Number;
            set
            {
                _Number = Utils.RemoveMask(value);
            }
        }

        public string ContactType { get; set; }
        public Guid? ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }
        public Guid? UserID { get; set; }
        public virtual User User {get; set; }
        public Guid? CatererID { get; set; }
        public virtual Caterer Caterer { get; set; }
        public void Update(User user) => User = user;
    }
}