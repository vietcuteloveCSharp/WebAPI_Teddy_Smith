using WebAPI_Teddy_Smith.Data;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            this._context = context;
        }
        //Category có tồn tại hay không
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }
        //list data của category
        public ICollection<Category> GetCategories()
        {
           return _context.Categories.ToList();
        }
        // lấy 1 object theo jd
        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
        //lấy poke theo id category
        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c=>c.CategoryId == categoryId).Select(c=>c.Pokemon).ToList();
        }
    }
}
