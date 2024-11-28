using System.Data.Entity;
using BangaloreWalks.api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetAll()
        {

             var Regions = dbContext.Regions.ToList();
            return Ok(Regions);
;        }

    }
}
