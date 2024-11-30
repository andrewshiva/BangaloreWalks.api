using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangaloreWalks.api.Data;
using BangaloreWalks.API.Models.DTO;

namespace BangaloreWalks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly BangaloreWalksDbContext dbContext;

        public RegionsController(BangaloreWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet] // Add HTTP verb attribute
        public IActionResult GetAll()
        {
            // Fetch regions from the database
            var regions = dbContext.Regions.ToList();


            var regionDto = new List<RegionDto>();
            foreach (var region in regions) {

                regionDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code

                });
            }

            return Ok(regions); // Return regions with 200 OK status


        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);


            if (region == null)
            {

                return NotFound();
            }
            var regionDto = new RegionDto {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code

            };


            return Ok(region);
        }

        

    }
}
