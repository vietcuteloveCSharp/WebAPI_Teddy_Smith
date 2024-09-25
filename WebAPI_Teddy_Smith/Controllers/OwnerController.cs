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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
        }
        //Lấy tất cả dữ liệu owner
        [HttpGet("get-owner")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetCategories()
        {   //xem kĩ hơn về phần maper
            var owners = _mapper.Map<List<OwnerDTO>>(_ownerRepository.GetOwners());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }
        //lấy dữ liệu pokemon theo id
        [HttpGet("ownerId")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            //check có owner tồn tại chưa 
            if (!_ownerRepository.OwnerExists(ownerId)) return NotFound();
            //check valid
            var owner = _mapper.Map<Owner>(_ownerRepository.GetOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //trả về data owner tìm được
            return Ok(owner);
        }
        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if(!_ownerRepository.OwnerExists(ownerId)) return NotFound();   
            var owner=_mapper.Map<List<PokemonDTO>>(_ownerRepository.GetPokemonByOwner(ownerId));
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(owner);
        }
    }
}
