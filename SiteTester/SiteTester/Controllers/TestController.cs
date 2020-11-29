using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteTester.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace SiteTester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ResourcesContext context;
        public TestController(ResourcesContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetCheckLogHistory()
        {
            return await context.Resources.ToListAsync();
        }
        [HttpGet("{url}")]
        public async Task<ActionResult<Resource>> CheckResource(string url)
        {
            var ping = new Ping();
            var resource = new Resource() { TestTime = DateTime.Now };

            try
            {
                var result = ping.Send(url);

                resource.Url = url;
                resource.Ping = result.RoundtripTime;
                resource.IsAvailable = result.Status == System.Net.NetworkInformation.IPStatus.Success;

            }
            catch (PingException e)
            {
                return BadRequest("Wrong Url or site doesn`t exist.");
            }
            context.Resources.Add(resource);
            await context.SaveChangesAsync();
            return resource;
            }

    }
}
