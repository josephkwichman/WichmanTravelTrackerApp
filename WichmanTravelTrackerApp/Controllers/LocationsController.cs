using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WichmanTravelTrackerApp.Models;
using WichmanTravelTrackerApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WichmanTravelTrackerApp.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        // GET: api/locations
        [HttpGet]
        public IEnumerable<LocationModel> Get()
        {
            return _locationService.GetAllLocations();
        }

        // POST api/locations
        [HttpPost]
        public void Post([FromBody] LocationModel inputLocation)
        {
            _locationService.AddALocation(inputLocation);
        }

        // PUT api/locations/5      
        [HttpPut]
        public void Put([FromBody]int id)
        {
            _locationService.ChangeALocationVisitedProperty(id);
        }

        private LocationsService _locationService = new LocationsService();
    }

}
