using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Catalyna.Core.DTOS;
using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalina.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryrepository, IMapper mapper)
        {
            _categoryRepository = categoryrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var catdto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return Ok(catdto);
        }
        
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult>GetCategory(int CategoryId)
        {
            var category = await _categoryRepository.GetCategory(CategoryId);
            var catdto = _mapper.Map<CategoryDTO>(category);
            return Ok(catdto);
        }

        public async Task<IActionResult> Category(CategoryDTO categorydto)
        {
            var category = _mapper.Map<Category>(categorydto);
            await _categoryRepository.InsertCategory(category);
            return Ok(category); 
        }

    }
}
