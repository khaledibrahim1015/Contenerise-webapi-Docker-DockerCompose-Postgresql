using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contenarise_webapi
{

  [Route("api/v1/[Controller]")]
  [ApiController]  
 public class DriversController :ControllerBase
 {
    private readonly ApiDbContext _context;
    private readonly ILogger<DriversController> _logger;
    public DriversController(ApiDbContext context,ILogger<DriversController> logger)
    {
        _logger = logger;
       _context = context;   
    }


    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Driver>),(int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Driver>>> Get()
    {
      
        var AllDrivers =  new List<Driver>()
        {
            new Driver()
            {
                Name = "khaled",
                DriverNumber = 4040
            },
            new Driver()
            {
                Name = "ahmed",
                DriverNumber = 4041
            },
            new Driver()
            {
                Name = "omar",
                DriverNumber = 4042
            }

        };
        await _context.AddRangeAsync(AllDrivers);
        await _context.SaveChangesAsync();

        var DriverList=await _context.Drivers.ToListAsync();
            return Ok(DriverList);

       





    }







 }

}