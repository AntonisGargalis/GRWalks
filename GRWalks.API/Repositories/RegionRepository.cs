using GRWalks.API.Data;
using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GRWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly GRWalksDbContext _dbContext;
        public RegionRepository(GRWalksDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }
        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FindAsync(id);
        }
        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            // check first if exist
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
        public async Task<Region?> DeleteAsync(Guid id)
        {
            // check first if exist
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            _dbContext.Regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }

    }
}
