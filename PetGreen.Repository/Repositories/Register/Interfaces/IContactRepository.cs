using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetByCatererID(Guid catererID);
        Task<List<Contact>> GetByClinicID(Guid clinicID);
    }
}
