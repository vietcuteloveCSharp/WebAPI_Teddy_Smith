using WebAPI_Teddy_Smith.Data;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            this._context = context;   
        }
        //lấy pokemon theo id
        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault() ?? null;
        }
        // lấy pokemon theo tên
        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault() ?? null;
        }
        //lấy rating theo id
        public decimal GetPokemonRating(int pokeId)
        {
            var reivew=_context.Reviews.Where(p=>p.Id == pokeId);
            if(reivew.Count() <= 0) return 0;
            return ((decimal)reivew.Sum(r=>r.Rating)/reivew.Count());
        }
        // lấy list pokemon
        public ICollection<Pokemon> GetPokemons()
        {
           return _context.Pokemons.OrderBy(p => p.Id).ToList() ??null;
        }
        // tìm pokemon đã tồn tại chưa 
        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p=>p.Id == pokeId);
        }
    }
}
