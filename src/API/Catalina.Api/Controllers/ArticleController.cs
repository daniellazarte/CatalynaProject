using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catalina.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articlerepository;
        public ArticleController(IArticleRepository articlerepository)
        {
            _articlerepository = articlerepository; //Inyeccion de dependencias
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await  _articlerepository.GetArticles();
            return Ok(articles);
        }

        [HttpGet("{ArticleId}")]
        public async Task<IActionResult> GetArticle(int ArticleId)
        {
            //IMplementacion de TRaer Articulo por ID
            var article = await _articlerepository.GetArticle(ArticleId);
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Article(Article article)
        {
            //IMplementacion de TRaer Articulo por ID
            await _articlerepository.InsertArticle(article);
            return Ok(article);
        }

    }
}
