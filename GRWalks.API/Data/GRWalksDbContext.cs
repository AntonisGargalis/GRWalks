using GRWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GRWalks.API.Data
{
    public class GRWalksDbContext : DbContext
    {
        public GRWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
