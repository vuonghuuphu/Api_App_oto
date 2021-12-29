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
    public class OdersController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public OdersController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/Oders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oder>>> GetOders(int id)
        {
            if (id != null)
            {
                var Oders = from m in _context.Oders
                           select m;

                Oders = Oders.Where(s => s.UserId == id);


                return await Oders.ToListAsync();
            }
            else
            {
                return await _context.Oders.ToListAsync();
            }
            return await _context.Oders.ToListAsync();
        }

        // GET: api/Oders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oder>> GetOder(int id)
        {
            var oder = await _context.Oders.FindAsync(id);

            if (oder == null)
            {
                return NotFound();
            }

            return oder;
        }

        // PUT: api/Oders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOder(int id, Oder oder)
        {
            if (id != oder.Id)
            {
                return BadRequest();
            }

            _context.Entry(oder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OderExists(id))
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

        // POST: api/Oders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oder>> PostOder(Oder oder)
        {
            _context.Oders.Add(oder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOder", new { id = oder.Id }, oder);
        }

        // DELETE: api/Oders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOder(int id)
        {
            var oder = await _context.Oders.FindAsync(id);
            if (oder == null)
            {
                return NotFound();
            }

            _context.Oders.Remove(oder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OderExists(int id)
        {
            return _context.Oders.Any(e => e.Id == id);
        }
    }
}
