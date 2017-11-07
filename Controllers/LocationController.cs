using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// curl --header "Content-Length:0" -X PUT "http://localhost:5000/api/location/a7b94dfb-2278-45aa-94dd-57ad695c3c7e?latitude=1.0&longitude=2.0&altitude=3.0"
// curl "http://localhost:5000/api/location" | json
// curl -X DELETE "http://localhost:5000/api/location/a7b94dfb-2278-45aa-94dd-57ad695c3c7e"

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class LocationController : Controller
    {
        protected LocationService LocationService;

        public LocationController() {
            LocationService = LocationService.Instance;
        }

        // GET api/location
        // Give me all guid/locations
        [HttpGet]
        public Dictionary<string, Location> Get()
        {
            var locations = LocationService.GetAllLocations();
            return locations;
        }

        // GET api/location/[guid]
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            var location = LocationService.GetLocation(guid);
            if (location == null) {
                return NotFound();
            }
            return Ok(location);
        }

        // PUT api/location/[guid]?latitude=1.0&longitude=2.0&altitude=3.0
        [HttpPut("{guid}")]
        public void Put(string guid, [FromQuery]double latitude, [FromQuery]double longitude, [FromQuery]double altitude)
        {
            var location = Location.Create(latitude, longitude, altitude);
            LocationService.SetLocation(guid, location);
        }

        // DELETE api/location/[guid]
        [HttpDelete("{guid}")]
        public void Delete(string guid)
        {
            LocationService.DeleteLocation(guid);
        }
    }
}
