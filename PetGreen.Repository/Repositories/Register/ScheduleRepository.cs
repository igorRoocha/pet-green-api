using Microsoft.EntityFrameworkCore;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly Db _context;

        public ScheduleRepository(Db context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetByClinicID(Guid clinicID)
        {
            return await _context.Schedules
                                 .Where(c => c.ClinicID == clinicID)
                                 .ToListAsync();
        }
    }
}
