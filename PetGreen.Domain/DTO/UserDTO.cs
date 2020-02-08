using System;
using System.Collections.Generic;
using PetGreen.Domain.Entities;

namespace PetGreen.Domain.DTO
{
    public class UserDto
    {
        public Guid ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Contact> Contacts { get; set; }

        public string Token { get; set; }

        public Profile Profile { get; set; }
    }
}