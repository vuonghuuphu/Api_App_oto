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
    public class oderServicesController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public oderServicesController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/oderServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<oderService>>> GetoderService()
        {
            return await _context.oderService.ToListAsync();
        }

        // GET: api/oderServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<oderService>> GetoderService(int id)
        {
            var oderService = await _context.oderService.FindAsync(id);

            if (oderService == null)
            {
                return NotFound();
            }

            return oderService;
        }

        // PUT: api/oderServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutoderService(int id, oderService oderService)
        {
            if (id != oderService.id)
            {
                return BadRequest();
            }

            _context.Entry(oderService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!oderServiceExists(id))
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

        // POST: api/oderServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<oderService>> PostoderService(oderService oderService)
        {
            _context.oderService.Add(oderService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetoderService", new { id = oderService.id }, oderService);
        }

        // DELETE: api/oderServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteoderService(int id)
        {
            var oderService = await _context.oderService.FindAsync(id);
            if (oderService == null)
            {
                return NotFound();
            }

            _context.oderService.Remove(oderService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool oderServiceExists(int id)
        {
            return _context.oderService.Any(e => e.id == id);
        }
    }
}
