using BangaloreWalks.api.Models.Domain;
using BangaloreWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BangaloreWalks.api.Data
{
    public class BangaloreWalksDbContext :DbContext
    {
        //public BangaloreWalksDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions) { 




        //}

        public BangaloreWalksDbContext(DbContextOptions<BangaloreWalksDbContext> options) : base(options)
        {

        }

        


        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }




    }
}
