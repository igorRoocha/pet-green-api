using Microsoft.EntityFrameworkCore;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetGreen.Repository.Repositories.Register
{
    public class UserRepository: IUserRepository
    {
        private readonly Db _context;

        public UserRepository(Db context)
        {
            _context = context;
        }

        /// <summary>
        /// Método responsável por carregar a empresa cadastrada no sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> Get(Guid id)
        {
            try
            {
                User user = await _context.User
                                            .AsNoTracking()
                                            .Include(c => c.Contacts)
                                            .Include(c => c.Profile)
                                            .Include(c => c.Clinic)
                                            .Where(c => c.ID == id)
                                            .FirstOrDefaultAsync();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
