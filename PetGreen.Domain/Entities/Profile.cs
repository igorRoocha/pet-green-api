using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using PetGreen.Entities.Interfaces;

namespace PetGreen.Domain.Entities
{
    [Table("CDProfile")]
    public class Profile : BaseEntity, IProfile
    {
        public Profile()
        {
            Users = new List<User>();
        }

        public string Description { get; set; }

        [JsonIgnore]
        public IReadOnlyCollection<User> Users {get; private set;}

        public void Update(string description) => Description = description;
    }
}