using PetGreen.Domain.DTO.Register;
using PetGreen.Domain.Entities.Register.Interfaces;
using PetGreen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Domain.Entities.Register
{
    public class Caterer : BaseEntity, ICaterer
    {
        public Caterer()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; set; }

        public string _TaxId;

        public string TaxId
        {
            get => _TaxId;
            set
            {
                _TaxId = Utils.RemoveMask(value);
            }
        }

        public string SocialReason { get; set; }

        public string StateRegistration { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }

        public IReadOnlyCollection<Address> Addresses { get; set; }

        public IReadOnlyCollection<Contact> Contacts { get; set; }

        public Guid ClinicID { get; set; }

        public virtual Clinic Clinic { get; set; }

        /// <summary>
        /// Converte o objeto CatererDTO para a entidade Caterer
        /// </summary>
        /// <param name="caterer"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Caterer FillCaterer(Caterer caterer, CatererDTO dto)
        {
            foreach (var property in dto.GetType().GetProperties())
            {
                var prop = caterer.GetType().GetProperty(property.Name);
                if (prop != null)
                {
                    var value = dto.GetType().GetProperty(property.Name).GetValue(dto);
                    caterer.GetType().GetProperty(property.Name).SetValue(caterer, value);
                }
            }

            return caterer;
        }
    }
}
