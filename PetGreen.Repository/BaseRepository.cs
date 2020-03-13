using PetGreen.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using PetGreen.Repository.Interfaces;
using PetGreen.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace PetGreen.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Db _context;

        public BaseRepository(Db context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            _context.Set<T>().Remove(await Get(id));
            _context.SaveChanges();
        }

        public async Task<IList<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }
    }
}