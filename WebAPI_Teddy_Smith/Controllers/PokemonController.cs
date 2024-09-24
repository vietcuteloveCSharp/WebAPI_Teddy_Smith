using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }
        [HttpGet("get-pokemons")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons= _pokemonRepository.GetPokemons();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
    }
}
