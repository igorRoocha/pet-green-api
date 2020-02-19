using Microsoft.EntityFrameworkCore;
using PetGreen.Application.Services.Interfaces.Register;
using PetGreen.Application.Services.Validators.Register;
using PetGreen.Domain.Entities;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Services.Register
{
    public class BreedService : BaseEntity, IBreedService
    {
        private readonly BaseService<Breed> _baseService;
        private readonly Db _context;

        public BreedService(Db context)
        {
            _context = context;
            _baseService = new BaseService<Breed>(context);
        }

        /// <summary>
        /// Adiciona um novo registro na tabela CDBreed
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> Register(Breed breed)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (BreedExists(breed))
                        return HttpStatusCode.Conflict;

                    breed.SpecieID = breed.Specie.ID;
                    //breed.Specie = null;
                    _baseService.Post<BreedValidator>(breed);
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

        /// <summary>
        /// Verifica se a raça que está sendo cadastrada já existe na base de dados
        /// </summary>
        /// <param name="specie"></param>
        /// <returns></returns>
        private bool BreedExists(Breed breed)
        {
            try
            {
                breed = (from s in _context.Breed
                         where s.Name == breed.Name
                         select s).FirstOrDefault();

                if (breed != null)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
