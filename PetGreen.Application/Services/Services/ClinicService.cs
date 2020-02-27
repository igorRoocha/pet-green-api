﻿using PetGreen.Application.Services.Interfaces;
using PetGreen.Domain.DTO;
using System.Linq;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using PetGreen.Application.Validators;
using PetGreen.Domain.Models;

namespace PetGreen.Application.Services.Services
{
    public class ClinicService : BaseEntity, IClinicService
    {
        private readonly BaseService<Clinic> _clinicService;
        private readonly BaseService<User> _userService;
        private readonly AddressService _addressService;
        private readonly Db _context;

        public ClinicService(Db context)
        {
            _context = context;
            _clinicService = new BaseService<Clinic>(context);
            _addressService = new AddressService(context);
            _userService = new BaseService<User>(context);
        }

        /// <summary>
        /// Adiciona um novo registro na tabela CDClinic
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> Register(ClinicDto dto)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (ClinicExists(dto))
                        return HttpStatusCode.Conflict;

                    Clinic clinic = new Clinic();
                    clinic = clinic.FillClinic(clinic, dto);

                    _addressService.Register(dto.Address);
                    clinic.AddressID = dto.Address.ID;
                    _clinicService.Post<ClinicValidator>(clinic);

                     await UpdateUser(clinic.ID, dto.UserID);

                    tran.Commit();
                    return HttpStatusCode.Created;
                }
                catch
                {
                    tran.Rollback();
                    throw ;
                }
            }
        }

        /// <summary>
        /// Verifica se a empresa que está sendo cadastrada já existe na base de dados
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private bool ClinicExists(ClinicDto dto)
        {
            try
            {
                Clinic clinic = (from c in _context.Clinic
                                 where c.TaxId == Utils.RemoveMask(dto.TaxId)
                                 select c).FirstOrDefault();

                if (clinic != null)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza o "CliniID" do usuário que está cadastrando a empresa no sistema
        /// </summary>
        /// <param name="clinicID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        private async Task UpdateUser(Guid clinicID, Guid userID)
        {
            User user = await _context.User.Include("Profile").Where(u => u.ID == userID).FirstOrDefaultAsync();
            user.ClinicID = clinicID;
            _userService.Put<UserValidator>(user);
        }
    }
}
