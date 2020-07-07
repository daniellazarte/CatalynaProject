using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Esta Service esta diseñado para las relas de Negocio, se crea una por entidad y se procede a hacer las reglas de validacion
//Con esto se agrega un nivel mas a la API. por que el servicio es ahora el encargado de ir al repo, y ya no la API directamente
namespace Catalyna.Core.Services
{
    public class CategoryService : ICategoryService //(CTRL +R +I en el nombre d ela clasepara crear la interface)
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<Category> GetCategory(int CategoryId)
        {
            return await _categoryRepository.GetCategory(CategoryId);
        }

        public async Task InsertCategory(Category category)
        {
            //Validaciones del Core de Negocio
            var user = await _userRepository.GetUser(category.UserId);
            if (user == null)
            {
                throw new Exception("User does´t exist");
            }

            if (category.Title.Contains("Sexo"))
            {
                throw new Exception("No authorize content: Include 'Sex or violence'");
            }
            await _categoryRepository.InsertCategory(category);

        }

        public async Task<bool> UpdateCategory(Category category)
        {
            return await _categoryRepository.UpdateCategory(category);
        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            return await _categoryRepository.DeleteCategory(CategoryId);
        }
    }
}
