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
    public class OderdetailsController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public OderdetailsController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/Oderdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oderdetail>>> GetOderdetails()
        {
            return await _context.Oderdetails.ToListAsync();
        }

        // GET: api/Oderdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oderdetail>> GetOderdetail(int id)
        {
            var oderdetail = await _context.Oderdetails.FindAsync(id);

            if (oderdetail == null)
            {
                return NotFound();
            }

            return oderdetail;
        }

        // PUT: api/Oderdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOderdetail(int id, Oderdetail oderdetail)
        {
            if (id != oderdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(oderdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OderdetailExists(id))
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

        // POST: api/Oderdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oderdetail>> PostOderdetail(Oderdetail oderdetail)
        {
            _context.Oderdetails.Add(oderdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOderdetail", new { id = oderdetail.Id }, oderdetail);
        }

        // DELETE: api/Oderdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOderdetail(int id)
        {
            var oderdetail = await _context.Oderdetails.FindAsync(id);
            if (oderdetail == null)
            {
                return NotFound();
            }

            _context.Oderdetails.Remove(oderdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OderdetailExists(int id)
        {
            return _context.Oderdetails.Any(e => e.Id == id);
        }
    }
}
