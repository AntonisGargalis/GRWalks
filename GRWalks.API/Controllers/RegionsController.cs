using AutoMapper;
using GRWalks.API.CustomActionFilters;
using GRWalks.API.Data;
using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;
using GRWalks.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionsController> _logger;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger) 
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll Action Method was invoked");            

            // getting data from data base - domain models
            var regionsDomain = await _regionRepository.GetAllAsync();

            //Map domain models to dtos Using AutoMapping
            var regionsDto = _mapper.Map<List<RegionDto>>(regionsDomain);

            _logger.LogInformation($"Finished Get all regions with data: {JsonSerializer.Serialize(regionsDomain)}");

            //return dtos only
            return Ok(regionsDto);
        }

        //ip: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionByid([FromRoute] Guid id) 
        {
            var regionDomain = await _regionRepository.GetRegionByIdAsync(id); 
            
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionsDto = _mapper.Map<RegionDto>(regionDomain);

            return Ok(regionsDto);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionDto addRegionDto)
        {
            //Map Dto to domain model
            var regionDomainModel = _mapper.Map<Region>(addRegionDto);

            // Use Domain Model to create Region
            await _regionRepository.CreateAsync(regionDomainModel);
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionDto updateRegionDto) 
        {
            //Map DTO to Domain Model
            var regionDomainModel = _mapper.Map<Region>(updateRegionDto);

            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var regionDto = _mapper.Map<UpdateRegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }      
    }
}
