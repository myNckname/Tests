using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SiteTester.Data;
using SiteTester.Filters;

namespace SiteTester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TesterExceptionsFilter]
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
            var result = ping.Send(url);
            var resource = new Resource()
            {
                TestTime = DateTime.Now,
                Url = url,
                Ping = result.RoundtripTime,
                IsAvailable = result.Status == IPStatus.Success
            };

            context.Resources.Add(resource);
            await context.SaveChangesAsync();

            return resource;
        }

    }
}
