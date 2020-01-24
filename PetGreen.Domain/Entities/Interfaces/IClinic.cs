using System;

namespace PetGreen.Entities.Interfaces
{
    public interface IClinic
    {
        void Update(DateTime? updatedAt, DateTime? deletedAt);
        
        void Update(string logo, string site, string socialReason);
    }
}