using PetGreen.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(Guid id);
    }
}
