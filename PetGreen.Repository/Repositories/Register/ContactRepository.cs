using Microsoft.EntityFrameworkCore;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register
{
    public class ContactRepository: BaseEntity, IContactRepository
    {
        private readonly Db _context;

        public ContactRepository(Db context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetByCatererID(Guid catererID)
        {
            return await _context.Contact
                                 .Where(c => c.CatererID == catererID)
                                 .ToListAsync();
        }

        public async Task<List<Contact>> GetByClinicID(Guid clinicID)
        {
            return await _context.Contact
                                 .Where(c => c.ClinicID == clinicID)
                                 .ToListAsync();
        }
    }
}
