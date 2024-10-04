using GRWalks.API.Data;
using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;
using GRWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly GRWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;

        public RegionsController(GRWalksDbContext dbContext, IRegionRepository regionRepository) 
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // getting data from data base - domain models
            var regionsDomain = await _regionRepository.GetAllAsync();

            //Map domain models to dtos
            var regionsDto = new List<RegionDto>();
            foreach (var region in regionsDomain) 
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            //return dtos only
            return Ok(regionsDto);
        }

        //ip: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionByid([FromRoute] Guid id) 
        {
            var regionDomain = await _regionRepository.GetRegionByIdAsync(id); //we use Find method only for id property

            // var regions = _dbContext.Regions.FirstOrDefaultAsync(x => x.Name == name); use any field, for ex "name" if it was in parameter

            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };          

            return Ok(regionsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionDto addRegionDto) 
        {
            //Map Dto to domain model
            var regionDomainModel = new Region
            {
                Name = addRegionDto.Name,
                Code = addRegionDto.Code,
                RegionImageUrl = addRegionDto.RegionImageUrl,
            };     
            
            // Use Domain Model to create Region
            await _regionRepository.CreateAsync(regionDomainModel);
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionDto updateRegionDto) 
        {
            //Map DTO to Domain Model
            var regionDomainModel = new Region
            {
                Name = updateRegionDto.Name,
                Code = updateRegionDto.Code,
                RegionImageUrl = updateRegionDto.RegionImageUrl
            };

            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
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
