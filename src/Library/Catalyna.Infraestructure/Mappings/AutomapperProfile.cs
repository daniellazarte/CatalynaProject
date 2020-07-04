using AutoMapper;
using Catalyna.Core.DTOS;
using Catalyna.Core.Entities;

namespace Catalyna.Infraestructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>();
        }
    }
}
