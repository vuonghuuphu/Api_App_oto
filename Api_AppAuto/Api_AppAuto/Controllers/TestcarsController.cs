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
    public class TestcarsController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public TestcarsController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/Testcars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testcar>>> GetTestcar(string phone,int id)
        {
            if (id != 0)
            {
                var test = from m in _context.Testcar
                              select m;

                test = test.Where(s => s.iduser == id);
                return await test.ToListAsync();
            }
            else if (phone != "n")
            {
                var test = from b in _context.Testcar select b;
                test = test.Where(s => s.Phonenumber == phone);
                return await test.ToListAsync();
            }
            else
            {
                return await _context.Testcar.ToListAsync();
            }
            //return await _context.Testcar.ToListAsync();
        }

        // GET: api/Testcars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testcar>> GetTestcar(int id)
        {
            var testcar = await _context.Testcar.FindAsync(id);

            if (testcar == null)
            {
                return NotFound();
            }

            return testcar;
        }

        // PUT: api/Testcars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestcar(int id, Testcar testcar)
        {
            if (id != testcar.id)
            {
                return BadRequest();
            }

            _context.Entry(testcar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestcarExists(id))
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

        // POST: api/Testcars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Testcar>> PostTestcar(Testcar testcar)
        {
            _context.Testcar.Add(testcar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestcar", new { id = testcar.id }, testcar);
        }

        // DELETE: api/Testcars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestcar(int id)
        {
            var testcar = await _context.Testcar.FindAsync(id);
            if (testcar == null)
            {
                return NotFound();
            }

            _context.Testcar.Remove(testcar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestcarExists(int id)
        {
            return _context.Testcar.Any(e => e.id == id);
        }
    }
}
