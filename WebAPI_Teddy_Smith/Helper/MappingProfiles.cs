using AutoMapper;
using WebAPI_Teddy_Smith.DTO;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
            
        }
    }
}
