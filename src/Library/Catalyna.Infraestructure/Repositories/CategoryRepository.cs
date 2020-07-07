using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyna.Infraestructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalynaMediaContext _context;
        public CategoryRepository(CatalynaMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return categories;

        }

        public async Task<Category> GetCategory(int CategoryId)
        {
            var category = await _context.Category.FirstOrDefaultAsync(x => x.CategoryId == CategoryId);
            return category;
        }

        public async Task InsertCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var currentcategory = await GetCategory(category.CategoryId);
            currentcategory.Title = category.Title;
            currentcategory.Description = category.Description;
            currentcategory.SiteId = category.SiteId;
            currentcategory.StateId = category.StateId;
            currentcategory.Order = category.Order;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            var currentcategory = await GetCategory(CategoryId);
            _context.Category.Remove(currentcategory);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
    }
}
