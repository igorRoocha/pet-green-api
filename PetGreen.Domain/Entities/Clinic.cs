using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PetGreen.Domain;
using PetGreen.Domain.DTO;
using PetGreen.Domain.Entities;
using PetGreen.Domain.Entities.Register;
using PetGreen.Domain.Models;
using PetGreen.Entities.Interfaces;

namespace PetGreen.Domain.Entities
{
    [Table("CDClinic")]
    public class Clinic : BaseEntity, IClinic
    {
        public Clinic()
        {
            Schedules = new List<Schedule>();
            Users = new List<User>();
            Contacts = new List<Contact>();
            CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; private set; }

        public string SocialReason { get; private set; }

        private string _TaxId;

        public string TaxId
        {
            get => _TaxId;
            set
            {
                _TaxId = Utils.RemoveMask(value);
            }
        }

        public string Email { get; private set; }

        public string Logo { get; private set; }

        public string Site { get; private set; }

        public string Facebook { get; private set; }

        public IReadOnlyCollection<User> Users { get; private set; }

        public IReadOnlyCollection<Contact> Contacts { get; private set; }

        public IReadOnlyCollection<Schedule> Schedules { get; private set; }

        public IReadOnlyCollection<Caterer> Caterers { get; set; }

        public Guid AddressID { get; set; }

        [NotMapped]
        public virtual Address Address { get; private set; }

        public void Update(DateTime? updatedAt, DateTime? deletedAt)
        {
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        public void Update(string logo, string site, string SocialReason)
        {
            Logo = logo;
            Site = site;
        }

        /// <summary>
        /// Converte o objeto ClinicDTO para a entidade Clinic
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Clinic FillClinic(Clinic clinic, ClinicDto dto)
        {
            foreach (var property in dto.GetType().GetProperties())
            {
                var prop = clinic.GetType().GetProperty(property.Name);
                if (prop != null)
                {
                    var value = dto.GetType().GetProperty(property.Name).GetValue(dto);
                    clinic.GetType().GetProperty(property.Name).SetValue(clinic, value);
                }
            }

            return clinic;
        }
    }
}