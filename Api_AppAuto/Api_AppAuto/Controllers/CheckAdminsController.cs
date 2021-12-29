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
    public class CheckAdminsController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public CheckAdminsController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/CheckAdmins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckAdmin>>> GetCheckAdmin(int id)
        {
            if (id != 0)
            {
                var CheckAdmin = from m in _context.CheckAdmin
                              select m;

                CheckAdmin = CheckAdmin.Where(s => s.iduser == id);
                return await CheckAdmin.ToListAsync();
            }
            else
            {
                return await _context.CheckAdmin.ToListAsync();
            }
        }

        // GET: api/CheckAdmins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckAdmin>> GetCheckAdmins(int id)
        {
            var checkAdmin = await _context.CheckAdmin.FindAsync(id);

            if (checkAdmin == null)
            {
                return NotFound();
            }

            return checkAdmin;
        }

        // PUT: api/CheckAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckAdmin(int id, CheckAdmin checkAdmin)
        {
            if (id != checkAdmin.id)
            {
                return BadRequest();
            }

            _context.Entry(checkAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckAdminExists(id))
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

        // POST: api/CheckAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckAdmin>> PostCheckAdmin(CheckAdmin checkAdmin)
        {
            _context.CheckAdmin.Add(checkAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckAdmin", new { id = checkAdmin.id }, checkAdmin);
        }

        // DELETE: api/CheckAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckAdmin(int id)
        {
            var checkAdmin = await _context.CheckAdmin.FindAsync(id);
            if (checkAdmin == null)
            {
                return NotFound();
            }

            _context.CheckAdmin.Remove(checkAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckAdminExists(int id)
        {
            return _context.CheckAdmin.Any(e => e.id == id);
        }
    }
}
