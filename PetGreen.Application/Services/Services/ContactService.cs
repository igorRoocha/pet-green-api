using PetGreen.Application.Services.Interfaces;
using PetGreen.Application.Validators;
using PetGreen.Domain.DTO;
using PetGreen.Domain.DTO.Register;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Services
{
    public class ContactService : BaseEntity, IContactService
    {
        private readonly BaseService<Contact> _baseService;
        private readonly ContactRepository _contactRepository;
        private readonly Db _context;

        public ContactService(Db context)
        {
            _context = context;
            _baseService = new BaseService<Contact>(context);
            _contactRepository = new ContactRepository(context);
        }

        /// <summary>
        /// Responsável por adicionar os contatos referente ao objeto que está sendo cadastrado
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="obj"></param>
        public void Register(List<Contact> contacts)
        {
            try
            {
                foreach (Contact c in contacts.ToList())
                {
                    _ = _baseService.Post<ContactValidator>(c);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por atualizar os contatos que se referem a empresa que está sendo atualizada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task Edit(ClinicDto dto)
        {
            try
            {
                List<Contact> contactsOfClinic = await _contactRepository.GetByClinicID(dto.ID);

                foreach (Contact c in contactsOfClinic)
                    await _baseService.Remove(c.ID);

                foreach (Contact contact in dto.Contacts)
                {
                    contact.ID = Guid.Empty;
                    contact.ClinicID = dto.ID;
                    _baseService.Post<ContactValidator>(contact);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método responsável por atualizar os contatos que se referem ao fornecedor que está sendo atualizado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task Edit(CatererDTO dto)
        {
            try
            {
                List<Contact> contactsOfCaterer = await _contactRepository.GetByCatererID(dto.ID);

                foreach (Contact c in contactsOfCaterer)
                    await _baseService.Remove(c.ID);

                foreach (Contact contact in dto.Contacts)
                {
                    contact.ID = Guid.Empty;
                    contact.CatererID = dto.ID;
                    _baseService.Post<ContactValidator>(contact);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove os registros de contatos que estão na tabela CDAddress a partir da lista enviada
        /// </summary>
        /// <param name="contatos"></param>
        public async Task Remove(IReadOnlyCollection<Contact> contacts)
        {
            try
            {
                foreach (Contact contact in contacts)
                {
                    await _baseService.Remove(contact.ID);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
