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
    public class ArticleRepository: IArticleRepository
    {
        private readonly CatalynaMediaContext _context;
        public ArticleRepository(CatalynaMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Article>> GetArticles()
        {
            var articles = await _context.Article.ToListAsync();
            return articles;
        }
    }
}
