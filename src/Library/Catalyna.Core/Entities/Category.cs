﻿namespace Catalyna.Core.Entities
{
    public class Category
    {
        public Category()
        {

        }
        public int CategoryId { get; set; }
        public int SiteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }
        public int Order { get; set; }
    }
}