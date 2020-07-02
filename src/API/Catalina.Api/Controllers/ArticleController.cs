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

    }
}
