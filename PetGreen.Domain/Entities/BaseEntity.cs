using Newtonsoft.Json;
using PetGreen.Domain.Models;
using System;
using System.ComponentModel;

namespace PetGreen.Domain.Entities
{
    public abstract class BaseEntity
    {
        [JsonConverter(typeof(NullToDefaultConverter<Guid>))]
        [DefaultValue(typeof(NullToDefaultConverter<Guid>))]
        public Guid ID{ get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}