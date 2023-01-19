using Catalog.Data.DTO;
using Catalog.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            List<CategoryDTO>? categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("pk/{categoryId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int categoryId)
        {
            CategoryDTO? categoryDTO = await _categoryService.GetById(categoryId);
            return categoryDTO == null ? NotFound() : Ok(categoryDTO);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDTO categoryDTO)
        {
            int isSuceess = await _categoryService.Add(categoryDTO);
            return isSuceess > 0 ? Ok(isSuceess) : BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            int isSuceess = await _categoryService.Update(categoryDTO);
            return isSuceess > 0 ? Ok() : BadRequest();
        }
        [HttpDelete("delete/{categoryId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int categoryId)
        {
            int isSuceess = await _categoryService.Delete(categoryId);
            return isSuceess > 0 ? Ok() : BadRequest();
        }
    }
}
