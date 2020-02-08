using PetGreen.Domain.DTO;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetGreen.Domain.Models;
using PetGreen.Application.Validators;
using PetGreen.Application.Services.Interfaces;

namespace PetGreen.Application.Services.Services
{
    public class UserService: IUserService
    {
        private readonly BaseService<User> _userService;
        private readonly BaseService<Contact> _contactService;
        private readonly Db _context;

        public UserService(Db context)
        {
            _context = context;
            _userService = new BaseService<User>(context);
            _contactService = new BaseService<Contact>(context);
        }

        /// <summary>
        /// Adiciona um novo registro na tabela CDUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> Register(UserDto dto)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (await (from r in _context.User where r.Email == dto.Email select r).FirstOrDefaultAsync() != null)
                        return HttpStatusCode.Conflict;

                    byte[] PasswordHash, PasswordSalt;

                    User user = new User();
                    user = user.FillUser(user, dto);

                    Cryptography.CripPassword(user.Password, out PasswordHash, out PasswordSalt);
                    user.PasswordHash = PasswordHash;
                    user.PasswordSalt = PasswordSalt;
                    user.Password = null;
                    user.Profile = await (from p in _context.Profile where p.Description == "Gestor" select p).FirstOrDefaultAsync();
                    _userService.Post<UserValidator>(user);

                    tran.Commit();
                    return HttpStatusCode.Created;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
