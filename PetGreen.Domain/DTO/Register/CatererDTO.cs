using PetGreen.Domain.Entities;
using PetGreen.Domain.Entities.Register;
using System;
using System.Collections.Generic;

namespace PetGreen.Domain.DTO.Register
{
    public class CatererDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string TaxId { get; set; }

        public string SocialReason { get; set; }

        public string StateRegistration { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }

        public List<Address> Address { get; set; }

        public List<Contact> Contacts { get; set; }

        public Guid UserID { get; set; }

        /// <summary>
        /// Converte o objeto Caterer para a entidade CatererDTO
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="caterer"></param>
        /// <returns></returns>
        public CatererDTO FillCaterer(CatererDTO dto, Caterer caterer)
        {
            foreach (var property in caterer.GetType().GetProperties())
            {
                var prop = dto.GetType().GetProperty(property.Name);
                if (prop != null)
                {
                    var value = caterer.GetType().GetProperty(property.Name).GetValue(caterer);
                    dto.GetType().GetProperty(property.Name).SetValue(dto, value);
                }
            }

            return dto;
        }
    }
}
