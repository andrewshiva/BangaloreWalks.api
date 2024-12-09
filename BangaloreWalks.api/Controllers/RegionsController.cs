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

   
        [HttpPost]

        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
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

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

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
        public IActionResult Update([FromRoute] Guid id ,[FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
          

            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return  NotFound();
            }

            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;

            dbContext.SaveChanges();

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
        public IActionResult Delete([FromRoute] Guid id)
        {
            // Find the region to delete
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                // Return 404 if not found
                return NotFound();
            }

            // Remove the region
            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

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
