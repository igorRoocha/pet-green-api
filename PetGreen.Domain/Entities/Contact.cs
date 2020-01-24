using PetGreen.Domain.Entities.Interfaces;
using PetGreen.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities
{
    [Table("CDContact")]
    public class Contact : BaseEntity, IContact
    {
        public Contact(string number)
        {
            Number = number;
        }
        public string Number { get; private set; }

        public Clinic Clinic { get; private set; }

        public User User {get; private set; }

        public void Update(User user) => User = user;

        public void Update(string number) => Number = number;
    }
}