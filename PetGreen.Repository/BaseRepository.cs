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

        public async Task Add(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            _context.Set<T>().Remove(await Get(id));
            await _context.SaveChangesAsync();
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