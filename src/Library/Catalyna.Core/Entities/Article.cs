using System;

namespace Catalyna.Core.Entities
{
    public partial class Article
    {
        public Article()
        {
            //Constructor
        }
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreate { get; set; }

    }
}
