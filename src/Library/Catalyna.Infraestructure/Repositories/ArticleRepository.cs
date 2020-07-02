using Catalyna.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Infraestructure.Repositories
{
    public class ArticleRepository
    { 
        public IEnumerable<Article> GetArticles()
        {
            var Articles = Enumerable.Range(1, 10).Select(x => new Article
            {
                ArticleId = x,
                Title = $"Title {x}",
                SubTitle = $"Subtitle {x}",
                Description = $"Descripcion {x}",
                DateCreate = DateTime.Now,
                UserId = x*2

            });

            return Articles;

        }
    }
}
