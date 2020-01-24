using PetGreen.Entities;

namespace PetGreen.Domain.Entities.Interfaces
{
    public interface IContact
    {
        void Update(User user);
         void Update(string contact);
    }
}