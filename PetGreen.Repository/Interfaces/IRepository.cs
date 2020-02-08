using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetGreen.Domain.Entities;

namespace PetGreen.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T obj);

        void Update(T obj);

        Task Remove(Guid id);

        Task<T> Get(Guid id);

        Task<IList<T>> Get();
    }
}