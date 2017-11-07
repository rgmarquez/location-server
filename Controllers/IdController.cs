using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class IdController : Controller
    {
        // GET api/values
        // data : {"guid": "55b83e77-3d56-4c08-8e8e-134278d63727"}
        [HttpGet]
        public object Get()
        {
            var g = Guid.NewGuid();
            return new { guid = g.ToString()};
        }
    }
}
