using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CatalynaMediaContext _context;
        private DbSet<T> _entities;
        public BaseRepository(CatalynaMediaContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByid(T id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           // T entity = await GetByid(id);
            //_entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

       
    }
}
