using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        bool PokemonExists(int pokeId);
    }
}
