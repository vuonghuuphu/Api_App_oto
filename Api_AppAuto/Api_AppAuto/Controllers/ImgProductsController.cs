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
    public class ImgProductsController : ControllerBase
    {
        private readonly Api_AutoContext _context;

        public ImgProductsController(Api_AutoContext context)
        {
            _context = context;
        }

        // GET: api/ImgProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgProduct>>> GetImgProduct(int idProduct)
        {
            if (idProduct != 0)
            {
                var IMG = from m in _context.ImgProduct
                           select m;

                IMG = IMG.Where(s => s.id_product == idProduct);
                return await IMG.ToListAsync();
            }
            else
            {
                return await _context.ImgProduct.ToListAsync();
            }
        }

        // GET: api/ImgProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgProduct>> GetImgProducts(int id)
        {
            var imgProduct = await _context.ImgProduct.FindAsync(id);

            if (imgProduct == null)
            {
                return NotFound();
            }

            return imgProduct;
        }

        // PUT: api/ImgProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImgProduct(int id, ImgProduct imgProduct)
        {
            if (id != imgProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(imgProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgProductExists(id))
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

        // POST: api/ImgProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgProduct>> PostImgProduct(ImgProduct imgProduct)
        {
            _context.ImgProduct.Add(imgProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImgProduct", new { id = imgProduct.id }, imgProduct);
        }

        // DELETE: api/ImgProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgProduct(int id)
        {
            var imgProduct = await _context.ImgProduct.FindAsync(id);
            if (imgProduct == null)
            {
                return NotFound();
            }

            _context.ImgProduct.Remove(imgProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgProductExists(int id)
        {
            return _context.ImgProduct.Any(e => e.id == id);
        }
    }
}
