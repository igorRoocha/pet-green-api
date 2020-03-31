using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register.Interfaces
{
    public interface IClinicRepository
    {
        Task<Clinic> Get(Guid id);
    }
}
