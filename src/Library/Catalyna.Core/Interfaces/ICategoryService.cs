using Catalyna.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyna.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int CategoryId);
        Task InsertCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int CategoryId);
    }
}