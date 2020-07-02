using System;

namespace Catalyna.Core.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreate { get; set; }


    }
}
