using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using PetGreen.Domain.Entities;

namespace PetGreen.Services.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        Task Remove(Guid id);

        Task<T> Get(Guid id);

        Task<IList<T>> Get();
    }
}