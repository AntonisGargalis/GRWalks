using AutoMapper;
using GRWalks.API.CustomActionFilters;
using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;
using GRWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository) 
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkDto addWalkDto)
        {
            //Map Dto to domain model
            var walkDomainModel = _mapper.Map<Walk>(addWalkDto);

            await _walkRepository.CreateAsync(walkDomainModel);

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            // getting data from data base - domain models
            var walksDomain = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending??true);

            //Map domain models to dtos Using AutoMapping
            var walksDto = _mapper.Map<List<WalkDto>>(walksDomain);

            //return dtos only
            return Ok(walksDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // getting data from data base - domain models
            var walkDomain = await _walkRepository.GetByIdAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            //Map domain models to dtos Using AutoMapping
            var walkDto = _mapper.Map<List<WalkDto>>(walkDomain);

            //return dtos only
            return Ok(walkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDto updateWalkDto)
        {
            //Map Dto to domain model
            var walkDomain = _mapper.Map<Walk>(updateWalkDto);

            walkDomain = await _walkRepository.UpdateAsync(id, walkDomain);

            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.DeleteAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
