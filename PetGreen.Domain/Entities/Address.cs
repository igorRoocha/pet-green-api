using PetGreen.Domain.Entities.Register;
using PetGreen.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGreen.Domain.Entities
{
    [Table("CDAddress")]
    public class Address : BaseEntity
    {
        public Address()
        {
            CreatedAt = DateTime.UtcNow;
        }
        private string _Cep;
        private Guid _CityID;

        public string Cep
        {
            get => _Cep;
            set
            {
                _Cep = Utils.RemoveMask(value);
            }
        }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public Guid CityID
        {
            get => _CityID;
            set
            {
                if (value == null)
                {
                    _CityID = Guid.Empty;
                }
                else
                {
                    _CityID = value;
                }
            }
        }
        public virtual City City { get; set; }
        public virtual Clinic Clinic { get; set; }
        public Guid? CatererID { get; set; }
        public virtual Caterer Caterer { get; set; }
    }
}
