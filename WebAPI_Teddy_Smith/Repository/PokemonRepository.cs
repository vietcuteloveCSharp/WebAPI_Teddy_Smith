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

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault() ?? null;
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault() ?? null;
        }

        

        public ICollection<Pokemon> GetPokemons()
        {
           return _context.Pokemons.OrderBy(p => p.Id).ToList() ??null;
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p=>p.Id == pokeId);
        }
    }
}
