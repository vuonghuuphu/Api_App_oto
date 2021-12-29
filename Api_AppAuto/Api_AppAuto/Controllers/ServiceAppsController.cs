using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_AppAuto.Models;

namespace Api_AppAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAppsController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public ServiceAppsController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/ServiceApps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceApp>>> GetServiceApp()
        {
            return await _context.ServiceApp.ToListAsync();
        }

        // GET: api/ServiceApps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceApp>> GetServiceApp(int id)
        {
            var serviceApp = await _context.ServiceApp.FindAsync(id);

            if (serviceApp == null)
            {
                return NotFound();
            }

            return serviceApp;
        }

        // PUT: api/ServiceApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceApp(int id, ServiceApp serviceApp)
        {
            if (id != serviceApp.id)
            {
                return BadRequest();
            }

            _context.Entry(serviceApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAppExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceApp>> PostServiceApp(ServiceApp serviceApp)
        {
            _context.ServiceApp.Add(serviceApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceApp", new { id = serviceApp.id }, serviceApp);
        }

        // DELETE: api/ServiceApps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceApp(int id)
        {
            var serviceApp = await _context.ServiceApp.FindAsync(id);
            if (serviceApp == null)
            {
                return NotFound();
            }

            _context.ServiceApp.Remove(serviceApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceAppExists(int id)
        {
            return _context.ServiceApp.Any(e => e.id == id);
        }
    }
}
