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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


             var difficulties  = new List<Difficulty>()
            {
                new Difficulty() {
                 Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),                   
                    Name = "Easy"

                },
                new Difficulty() {
            Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), // Valid Guid
                    Name = "Medium"

                },
                new Difficulty()
                {
            Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"), // Valid Guid
                    Name = "Hard"
                }
            


          };



            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
    {
        new Region
        {
            Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), // Valid Guid
            Name = "Koramangala",
            Code = "KOR",
            RegionImageUrl = "https://images.pexels.com/photos/15060030/pexels-photo-15060030.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        },
        new Region
        {
            Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), // Valid Guid
            Name = "Indiranagar",
            Code = "IND",
            RegionImageUrl = "https://images.pexels.com/photos/416416/pexels-photo-416416.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        },
        new Region
        {
            Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"), // Valid Guid
            Name = "Whitefield",
            Code = "WHF",
            RegionImageUrl = "https://images.pexels.com/photos/417011/pexels-photo-417011.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        },
        new Region
        {
            Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), // Valid Guid
            Name = "Electronic City",
            Code = "ELC",
            RegionImageUrl = "https://images.pexels.com/photos/2132213/pexels-photo-2132213.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        },
        new Region
        {
            Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
            Name = "Hebbal",
            Code = "HEB",
            RegionImageUrl = "https://images.pexels.com/photos/1098365/pexels-photo-1098365.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        },
        new Region
        {
            Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
            Name = "Jayanagar",
            Code = "JYN",
            RegionImageUrl = "https://images.pexels.com/photos/2437293/pexels-photo-2437293.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        },
        new Region
        {
            Id = Guid.Parse("a1b2c3d4-e5f6-7890-ab12-cdef34567890"),
            Name = "Malleswaram",
            Code = "MLS",
            RegionImageUrl = "https://images.pexels.com/photos/240222/pexels-photo-240222.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        }
    };

            modelBuilder.Entity<Region>().HasData(regions);


        }




    }


}
