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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties (easy, medium, hard)
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("a6f659ed-e040-42a9-80ca-60318dc9682f"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("29584951-fab9-49b0-971b-5beb9dcb1fb2"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("cc3576f3-cc0b-4798-9075-39dd960b0e0b"),
                    Name = "Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions (easy, medium, hard)
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("4083319c-5aa3-4527-850f-9d65b1c08ea8"),
                    Name = "Central Greece",
                    Code = "CG",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Location_map_of_CentralGreece_%28Greece%29.svg/1200px-Location_map_of_CentralGreece_%28Greece%29.svg.png"
                },
                new Region()
                {
                    Id = Guid.Parse("ebc8cfba-8311-47db-a979-0ff008a48e3f"),
                    Name = "Peleponnese",
                    Code = "PL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Location_map_of_Peloponnese_%28Greece%29.svg/1200px-Location_map_of_Peloponnese_%28Greece%29.svg.png"
                },
                new Region()
                {
                    Id = Guid.Parse("56df7c1e-2f30-4de4-8996-972297a27d1d"),
                    Name = "Thessaly",
                    Code = "TS",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Location_map_of_Thessaly_%28Greece%29.svg/800px-Location_map_of_Thessaly_%28Greece%29.svg.png"
                },
                new Region()
                {
                    Id = Guid.Parse("fbe553ae-2d46-46c0-a950-c8655988c403"),
                    Name = "Epirus",
                    Code = "EP",
                    RegionImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDvkxKw7Y3e2kIe6tSPqLaE5cQ2qATwcfpfg&s"
                },
                new Region()
                {
                    Id = Guid.Parse("d4e17e88-7fcb-4001-8792-e1550bd67426"),
                    Name = "Macedonia",
                    Code = "MD",
                    RegionImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRLZ5Ewoc38qb7ABx-22X_oA56vormcLrezGw&s"
                },
                new Region()
                {
                    Id = Guid.Parse("d9024e7f-1a6a-4c34-aa67-770b051e2b56"),
                    Name = "Thrace",
                    Code = "TH",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/Location_map_of_Thrace_%28Greece%29.svg/1200px-Location_map_of_Thrace_%28Greece%29.svg.png"
                },
                new Region()
                {
                    Id = Guid.Parse("30041b4f-0368-4b58-b48f-2bf3f374da17"),
                    Name = "Aegean Islands",
                    Code = "AI",
                    RegionImageUrl = "https://mice.gr/wp-content/uploads/2017/01/aegean_islands.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("9467927f-2dd2-401d-8489-9acec073d257"),
                    Name = "Ionian Islands",
                    Code = "II",
                    RegionImageUrl = "https://mice.gr/wp-content/uploads/2017/01/ionian.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
