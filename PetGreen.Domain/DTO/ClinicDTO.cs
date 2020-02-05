using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PetGreen.Domain.DTO
{
    public class ClinicDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Facebook { get; set; }
        public string Logo { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
