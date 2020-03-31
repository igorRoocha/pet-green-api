using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetByClinicID(Guid clinicID);
    }
}
