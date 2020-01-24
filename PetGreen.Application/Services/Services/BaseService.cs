using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using PetGreen.Domain.Entities;
using PetGreen.Repository;
using PetGreen.Repository.Context;
using PetGreen.Services.Interfaces;

namespace PetGreen.Application.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> repository;
        private readonly Db _context;

        public BaseService(Db context)
        {
            _context = context;
            repository = new BaseRepository<T>(context);
        }

        public async Task<T> Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            await repository.Add(obj);
            return obj;
        }

        public async Task<T> Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            await repository.Update(obj);
            return obj;
        }

        public async Task Remove(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("The id can't be empty.");

            await repository.Remove(id);
        }

        public async Task<IList<T>> Get() => await repository.Get();

        public async Task<T> Get(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("The id can't be empty.");

            return await repository.Get(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registers not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}