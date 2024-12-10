using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangaloreWalks.api.Data;
using BangaloreWalks.API.Models.DTO;
using System.Linq;
using System.Drawing;
using System;
using BangaloreWalks.api.Models.DTO;
using BangaloreWalks.API.Models.Domain;
using Region = BangaloreWalks.API.Models.Domain.Region;

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
        public  async Task <IActionResult> GetAll()
        {
            // Fetch regions from the database
            var regions =  await dbContext.Regions.ToListAsync();


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
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region =  await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);


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

   
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (addRegionRequestDto == null)
            {
                return BadRequest("Region data is required.");
            }

            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code
            };

           await dbContext.Regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name
            };

            // Assuming GetById takes an ID and returns the created region
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id ,[FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
          

            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return  NotFound();
            }

            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;

            await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name
            };

            return Ok(regionDomainModel);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Find the region to delete
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                // Return 404 if not found
                return NotFound();
            }

            // Remove the region
            dbContext.Regions.Remove(regionDomainModel);
           await  dbContext.SaveChangesAsync();

            // Map the deleted region to a DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name
            };

            // Return the deleted region as a DTO
            return Ok(regionDto);
        }


    }
}
