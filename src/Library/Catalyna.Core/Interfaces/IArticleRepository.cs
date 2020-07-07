using Catalyna.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyna.Core.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int ArticleId);
        Task InsertArticle(Article article);



    }
}
