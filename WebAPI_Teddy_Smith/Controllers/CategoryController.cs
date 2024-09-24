using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Teddy_Smith.DTO;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;
using WebAPI_Teddy_Smith.Repository;

namespace WebAPI_Teddy_Smith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {   private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }
        //Lấy tất cả dữ liệu category
        [HttpGet("get-categories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {   //xem kĩ hơn về phần maper
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }
        //lấy dữ liệu category theo id
        [HttpGet("categoryId")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            //check có category tồn tại chưa 
            if (!_categoryRepository.CategoryExists(categoryId)) return NotFound();
            //check valid
            var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //trả về data category tìm được
            return Ok(category);
        }
        //get pokem/categoryid
        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryByCategoryId(int categoryId)
        {
            var pokemons=_mapper.Map<List<PokemonDTO>>(_categoryRepository.GetPokemonByCategory(categoryId));
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(pokemons);
        }

    }
}
