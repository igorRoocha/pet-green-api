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
    public class ClinicRepository: IClinicRepository
    {
        private readonly Db _context;

        public ClinicRepository(Db context)
        {
            _context = context;
        }
        /// <summary>
        /// Método responsável por carregar a empresa cadastrada no sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Clinic> Get(Guid id)
        {
            try
            {
                Clinic clinic = await _context.Clinic
                                                    .AsNoTracking()
                                                    .Include(c => c.Address)
                                                        .ThenInclude(address => address.City)
                                                            .ThenInclude(city => city.State)
                                                    .Include(c => c.Contacts)
                                                    .Include(c => c.Schedules)
                                                    .Include(c => c.Users)
                                                    .Where(c => c.ID == id)
                                                    .FirstOrDefaultAsync();
                return clinic;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
