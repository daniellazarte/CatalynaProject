namespace Catalyna.Core.DTOS
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {

        }
        public int CategoryId { get; set; }
        public int SiteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }
        public int Order { get; set; }
        public int UserId { get; set; }
    }
}
