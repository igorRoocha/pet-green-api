using PetGreen.Application.Services.Interfaces;
using PetGreen.Application.Validators;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetGreen.Application.Services.Services
{
    public class ContactService : BaseEntity, IContactService
    {
        private readonly BaseService<Contact> _baseService;
        private readonly Db _context;

        public ContactService(Db context)
        {
            _context = context;
            _baseService = new BaseService<Contact>(context);

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
    }
}
