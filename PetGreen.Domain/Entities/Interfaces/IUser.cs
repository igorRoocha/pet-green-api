using System;

namespace PetGreen.Entities.Interfaces
{
    public interface IUser
    {
        void Update(bool active);

        void Update(DateTime? updatedAt, DateTime? deletedAt);

        void Update(bool active, DateTime? updatedAt, DateTime? deletedAt);

    }
}