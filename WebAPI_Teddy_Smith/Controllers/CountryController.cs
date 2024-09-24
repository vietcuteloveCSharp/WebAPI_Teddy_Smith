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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository,IMapper mapper)
        {
            this._countryRepository = countryRepository;
            this._mapper = mapper;
        }
        //Lấy tất cả dữ liệu country
        [HttpGet("get-country")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {   //xem kĩ hơn về phần maper
            var countries = _mapper.Map<List<CountryDTO>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(countries);
        }
        //lấy dữ liệu country theo id
        [HttpGet("pokeId")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryn(int countryId)
        {
            //check có country tồn tại chưa 
            if (!_countryRepository.countriesExist(countryId)) return NotFound();
            //check valid
            var country = _mapper.Map<CountryDTO>(_countryRepository.GetCountry(countryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //trả về data country tìm được
            return Ok(country);
        }
        [HttpGet("/owner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country= _mapper.Map<CountryDTO>(_countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //trả về data country tìm được
            return Ok(country);
        }
    }
}
