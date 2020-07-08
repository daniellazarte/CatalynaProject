using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalynaMediaContext _context;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Category> _categoryRepository;
        //private readonly IRepository<User> _userRepository;
        public UnitOfWork(CatalynaMediaContext context)
        {
            _context = context;
        }
        public IRepository<Article> PostRepository => _articleRepository ?? new BaseRepository<Article>(_context);

        public IRepository<Category> CategoryRepository => _categoryRepository ?? new BaseRepository<Category>(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
