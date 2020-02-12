using System;

namespace PetGreen.Domain.Entities.Register
{
    public class Specie: BaseEntity
    {
        public Specie()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public string Name { get; set; }
    }
}
