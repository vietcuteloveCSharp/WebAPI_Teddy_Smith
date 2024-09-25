using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Interface
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int id);
        ICollection<Owner> GetOwnerOfPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}
