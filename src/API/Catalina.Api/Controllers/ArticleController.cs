using Catalyna.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalina.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetArticles()
        {
            var articles = new ArticleRepository().GetArticles();
            return Ok(articles);
        }

    }
}
