using AutoMapper;
using Catalyna.Core.DTOS;
using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalina.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articlerepository;
        private readonly IMapper _mapper;
        
        public ArticleController(IArticleRepository articlerepository,IMapper mapper)
        {
            _articlerepository = articlerepository; //Inyeccion de dependencias
            //registrar el AUtomapper
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await  _articlerepository.GetArticles();
            var ardtos = _mapper.Map<IEnumerable<ArticleDTO>>(articles);

            return Ok(ardtos);
        }

        [HttpGet("{ArticleId}")]
        public async Task<IActionResult> GetArticle(int ArticleId)
        {
            //IMplementacion de TRaer Articulo por ID
            var article = await _articlerepository.GetArticle(ArticleId);
            var ardto = _mapper.Map<ArticleDTO>(article);

            return Ok(ardto);
        }

        [HttpPost]
        public async Task<IActionResult> Article(ArticleDTO articleDTO)
        {
            //IMplementacion de TRaer Articulo por ID
            var article = _mapper.Map<Article>(articleDTO);
            await _articlerepository.InsertArticle(article);
            return Ok(article);
        }

    }
}
