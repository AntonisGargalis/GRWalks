using GRWalks.API.Data;
using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;
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

        public RegionsController(GRWalksDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // getting data from data base - domain models
            var regionsDomain = await _dbContext.Regions.ToListAsync();

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
            var regionDomain = await _dbContext.Regions.FindAsync(id); //we use Find method only for id property

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
            await _dbContext.Regions.AddAsync(regionDomainModel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionDto updateRegionDto) 
        {
            // check first if exist
            var regionDomain = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map DTO to Domain model
            regionDomain.Name = updateRegionDto.Name;
            regionDomain.Code = updateRegionDto.Code;
            regionDomain.RegionImageUrl = updateRegionDto.RegionImageUrl;

            await _dbContext.SaveChangesAsync();

            //Convert Domain Model to Dto
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            _dbContext.Regions.Remove(regionDomain);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }      
    }
}
