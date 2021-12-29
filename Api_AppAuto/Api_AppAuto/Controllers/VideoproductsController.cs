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
    public class VideoproductsController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public VideoproductsController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/Videoproducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videoproduct>>> GetVideoproduct(int id)
        {
            if (id != 0)
            {
                var video = from m in _context.Videoproduct
                          select m;

                video = video.Where(s => s.id_product == id);
                return await video.ToListAsync();
            }
            else
            {
                return await _context.Videoproduct.ToListAsync();
            }
        }

        // GET: api/Videoproducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videoproduct>> GetVideoproducts(int id)
        {
            var videoproduct = await _context.Videoproduct.FindAsync(id);

            if (videoproduct == null)
            {
                return NotFound();
            }

            return videoproduct;
        }

        // PUT: api/Videoproducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoproduct(int id, Videoproduct videoproduct)
        {
            if (id != videoproduct.id)
            {
                return BadRequest();
            }

            _context.Entry(videoproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoproductExists(id))
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

        // POST: api/Videoproducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videoproduct>> PostVideoproduct(Videoproduct videoproduct)
        {
            _context.Videoproduct.Add(videoproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoproduct", new { id = videoproduct.id }, videoproduct);
        }

        // DELETE: api/Videoproducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoproduct(int id)
        {
            var videoproduct = await _context.Videoproduct.FindAsync(id);
            if (videoproduct == null)
            {
                return NotFound();
            }

            _context.Videoproduct.Remove(videoproduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoproductExists(int id)
        {
            return _context.Videoproduct.Any(e => e.id == id);
        }
    }
}
