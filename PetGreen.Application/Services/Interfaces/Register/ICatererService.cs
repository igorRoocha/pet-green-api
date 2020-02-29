using PetGreen.Domain.Entities.Register;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces.Register
{
    public interface ICatererService
    {
        Task<List<Caterer>> GetByClinicID(Guid clinicID);
    }
}
