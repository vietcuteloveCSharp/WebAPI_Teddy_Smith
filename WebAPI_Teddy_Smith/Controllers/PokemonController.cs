using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebAPI_Teddy_Smith.DTO;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this._pokemonRepository = pokemonRepository;
            this._mapper = mapper;
        }
        //Lấy tất cả dữ liệu pokemon
        [HttpGet("get-pokemons")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {   //xem kĩ hơn về phần maper
            var pokemons= _mapper.Map<List<PokemonDTO>>(_pokemonRepository.GetPokemons());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
        //lấy dữ liệu pokemon theo id
        [HttpGet("pokeId")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
           //check có pokemon tồn tại chưa 
            if (!_pokemonRepository.PokemonExists(pokeId)) return NotFound();
            //check valid
            var pokemon= _mapper.Map<PokemonDTO>(_pokemonRepository.GetPokemon(pokeId));
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            //trả về data pokemon tìm được
            return Ok(pokemon);
        }
        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            //check có pokemon tồn tại chưa 
            if (!_pokemonRepository.PokemonExists(pokeId)) return NotFound();
            //check valid
            var rating = _pokemonRepository.GetPokemonRating(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //trả về data pokemon tìm được
            return Ok(rating);
        }
    }
}
