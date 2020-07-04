using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Core.DTOS
{
    public class ArticleDTO
    {
        // Ya con el DTO presento solo informacion que deseo que se resalte al usuario
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        //public string LedTopTitle { get; set; }
        //public string LedBottomTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        //public int SitePosition { get; set; }
        //public int CategoryId { get; set; }
        //public int Priority { get; set; }
        //public string Hour { get; set; }
        //public DateTime Date { get; set; }
        //public int SiteId { get; set; }
        //public int ArticleTypeId { get; set; }
        //public int StateId { get; set; }
        //public string EnabledComments { get; set; } //E or D
        //public string EnabledReaction { get; set; } //E or D
        public string Tags { get; set; } //E or D
        public string UserId { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
