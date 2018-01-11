using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Spot.StatsManagement.Core.Interfaces.Repositories;

namespace Spot.Controllers
{
    [Produces("application/json")]
    [Route("api/Stats")]
    public class StatsController : Controller
    {
        private readonly IFacilityRepository _facilityRepository;

        public StatsController(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        // GET: api/Stats
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var facilities = _facilityRepository.GetAll(true).ToList();
                return Ok(facilities);
            }
            catch (Exception e)
            {
                Log.Error($"{e}");
                return StatusCode(500, $"{e.Message}");
            }
        }

        // GET: api/Stats/search
        [HttpGet("{search}")]
        public IActionResult Get(string search)
        {
            try
            {
                var facilities = _facilityRepository.GetAllBy(search,true).ToList();

                if (facilities.Count==0)
                    return NotFound();

                return Ok(facilities);
            }
            catch (Exception e)
            {
                Log.Error($"{e}");
                return StatusCode(500, $"Error loading Stats");
            }
        }

    }
}
