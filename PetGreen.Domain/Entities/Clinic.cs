using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PetGreen.Domain;
using PetGreen.Domain.Entities;
using PetGreen.Entities.Interfaces;

namespace PetGreen.Domain.Entities
{
    [Table("CDClinic")]
    public class Clinic : BaseEntity, IClinic
    {
        public Clinic(string name, string taxId, string email)
        {
            Name = name;
            TaxId = taxId;
            Email = email;
            Schedules = new List<Schedule>();
            Users = new List<User>();
            Contacts = new List<Contact>();
            CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; private set; }

        public string SocialReason { get; private set; }

        public string TaxId { get; private set; }

        public string Email { get; private set; }

        public string Logo { get; private set; }

        public string Site { get; private set; }

        public string Facebook { get; private set; }

        public IReadOnlyCollection<User> Users { get; private set; }

        public IReadOnlyCollection<Contact> Contacts { get; private set; }

        public IReadOnlyCollection<Schedule> Schedules { get; private set; }

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
    }
}