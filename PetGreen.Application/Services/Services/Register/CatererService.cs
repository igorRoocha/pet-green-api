using PetGreen.Domain.Entities;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PetGreen.Domain.DTO.Register;
using PetGreen.Application.Services.Validators.Register;
using Microsoft.EntityFrameworkCore;
using PetGreen.Application.Services.Interfaces.Register;
using PetGreen.Application.Services.Validators;
using PetGreen.Application.Validators;
using PetGreen.Repository.Repositories.Register;

namespace PetGreen.Application.Services.Services.Register
{
    public class CatererService : ICatererService
    {
        private readonly BaseService<Caterer> _catererService;
        private readonly BaseService<Contact> _bsContactService;
        private readonly BaseService<User> _userService;
        private readonly BaseService<Address> _bsAddressService;
        private readonly AddressService _addressService;
        private readonly ContactService _contactService;
        private readonly ContactRepository _contactRepository;
        private readonly Db _context;

        public CatererService(Db context)
        {
            _context = context;
            _addressService = new AddressService(context);
            _bsAddressService = new BaseService<Address>(context);
            _bsContactService = new BaseService<Contact>(context);
            _catererService = new BaseService<Caterer>(context);
            _contactService = new ContactService(context);
            _contactRepository = new ContactRepository(context);
            _userService = new BaseService<User>(context);
        }

        #region [PUBLIC]
        /// <summary>
        /// Adiciona um novo registro na tabela CDCaterer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> Register(CatererDTO dto)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    User user = await _userService.Get(dto.UserID);

                    Caterer caterer = new Caterer();
                    caterer = caterer.FillCaterer(caterer, dto);
                    caterer.ClinicID = (Guid)user.ClinicID;

                    if (CatererExists(caterer))
                        return HttpStatusCode.Conflict;

                    caterer.Address = null;
                    _catererService.Post<CatererValidator>(caterer);
                    AddAddress(dto.Address, caterer.ID);

                    tran.Commit();
                    return HttpStatusCode.OK;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Atualiza o fornecedor que está na tabela CDCaterer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> Edit(CatererDTO dto)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    Caterer caterer = await _catererService.Get(dto.ID);
                    caterer = caterer.FillCaterer(caterer, dto);

                    if (CatererExists(caterer))
                        return HttpStatusCode.Conflict;

                    caterer.Contacts = null;
                    caterer.Address = null;
                    _catererService.Put<CatererValidator>(caterer);

                    _addressService.Edit(dto);
                    await _contactService.Edit(dto);

                    tran.Commit();
                    return HttpStatusCode.OK;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Método responsável por excluir um fornecedor do banco de dados
        /// </summary>
        /// <param name="clinicID"></param>
        /// <returns></returns>
        public async Task Remove(Guid id)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    Caterer caterer = await _context.Caterer
                                                .AsNoTracking()
                                                .Include(c => c.Address)
                                                .Include(c => c.Contacts)
                                                .Where(c => c.ID == id)
                                                .FirstOrDefaultAsync();

                    if (caterer != null)
                    {
                        await _addressService.Remove(caterer.Address);
                        await _contactService.Remove(caterer.Contacts);
                        await _catererService.Remove(caterer.ID);
                    }

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }


        /// <summary>
        /// Método responsável por carregar todos os fornecedores referente a clínica que está sendo enviada no parâmetro
        /// </summary>
        /// <param name="clinicID"></param>
        /// <returns></returns>
        public async Task<List<Caterer>> GetByClinicID(Guid clinicID)
        {
            try
            {
                List<Caterer> caterers = await _context.Caterer
                                                    .AsNoTracking()
                                                    .Include(c => c.Clinic)
                                                    .Include(c => c.Address)
                                                        .ThenInclude(address => address.City)
                                                            .ThenInclude(city => city.State)
                                                    .Include(c => c.Contacts)
                                                    .Where(c => c.ClinicID == clinicID)
                                                    .ToListAsync();

                return caterers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [PRIVATE]
        /// <summary>
        /// Método responsável por adicionar todos os endereços pertencentes ao fornecedor
        /// </summary>
        /// <param name="caterer"></param>
        /// <returns></returns>
        private void AddAddress(List<Address> addresses, Guid catererID)
        {
            foreach (Address address in addresses)
            {
                address.CatererID = catererID;
                _addressService.Register(address);
            }
        }

        /// <summary>
        /// Verifica se o fornecedor que está sendo cadastrado já existe na base de dados
        /// </summary>
        /// <param name="caterer"></param>
        /// <returns></returns>
        private bool CatererExists(Caterer caterer)
        {
            try
            {
                caterer = (from c in _context.Caterer
                           where c.TaxId == caterer.TaxId && c.ClinicID == caterer.ClinicID &&
                                 c.ID != caterer.ID
                           select c).FirstOrDefault();

                if (caterer != null)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
