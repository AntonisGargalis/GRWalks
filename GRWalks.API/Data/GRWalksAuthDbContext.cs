using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace GRWalks.API.Data
{
    public class GRWalksAuthDbContext: IdentityDbContext
    {
        public GRWalksAuthDbContext(DbContextOptions<GRWalksAuthDbContext> options): base (options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "a0f876e0-670f-4be8-8edb-5632a30da084";
            var writerRoleId = "378f1d5f-dc4f-4202-989f-02f374ffd02d";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                   Id = readerRoleId,
                   ConcurrencyStamp = readerRoleId,
                   Name = "Reader",
                   NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                   Id = writerRoleId,
                   ConcurrencyStamp = writerRoleId,
                   Name = "Writer",
                   NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
