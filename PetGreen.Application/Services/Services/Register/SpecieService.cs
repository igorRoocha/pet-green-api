using PetGreen.Application.Services.Validators.Register;
using PetGreen.Domain.Entities;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace PetGreen.Application.Services.Services.Register
{
    public class SpecieService: BaseEntity
    {
        private readonly BaseService<Specie> _specieService;
        private readonly Db _context;

        public SpecieService(Db context)
        {
            _context = context;
            _specieService = new BaseService<Specie>(context);
        }

        /// <summary>
        /// Adiciona um novo registro na tabela CDSpecie
        /// </summary>
        /// <param name="specie"></param>
        /// <returns></returns>
        public HttpStatusCode Register(Specie specie)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (SpecieExists(specie))
                        return HttpStatusCode.Conflict;

                    _specieService.Post<SpecieValidator>(specie);
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
        /// Verifica se a espécie que está sendo cadastrada já existe na base de dados
        /// </summary>
        /// <param name="specie"></param>
        /// <returns></returns>
        private bool SpecieExists(Specie specie)
        {
            try
            {
                Specie clinic = (from s in _context.Specie
                                 where s.Name == specie.Name
                                 select s).FirstOrDefault();

                if (clinic != null)
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
