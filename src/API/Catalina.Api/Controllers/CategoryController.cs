using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Catalina.Api.Responses;
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
        private readonly ICategoryService _categoryservice;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryrepository, IMapper mapper)
        {
            _categoryservice = categoryrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryservice.GetCategories();
            var catsDTOS = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            //var response = new APIResponse<IEnumerable<CategoryDTO>>(catsDTOS);

            return Ok(catsDTOS);
        }
        
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult>GetCategory(int CategoryId)
        {
            var category = await _categoryservice.GetCategory(CategoryId);
            var catdto = _mapper.Map<CategoryDTO>(category);

            //var response = new APIResponse<CategoryDTO>(catdto);
            return Ok(catdto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDTO categorydto)
        {
            var category = _mapper.Map<Category>(categorydto);
            await _categoryservice.InsertCategory(category);

            categorydto = _mapper.Map<CategoryDTO>(category);
            var response = new APIResponse<CategoryDTO>(categorydto);
            return Ok(response); 
        }

        [HttpPut]
        public async Task<IActionResult> Put(int CategoryId, CategoryDTO categorydto)
        {
            var category = _mapper.Map<Category>(categorydto);
            category.CategoryId = CategoryId;

            var result = await _categoryservice.UpdateCategory(category);
            //var response = new APIResponse<bool>(result);
            return Ok(result);
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> Delete(int CategoryId)
        {
           
            var result = await _categoryservice.DeleteCategory(CategoryId);
            //var response = new APIResponse<bool>(result);
            return Ok(result);
        }


    }
}
