using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngcd4.Models;

namespace ngcd4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbimagesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public DbimagesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Dbimages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbimage>>> GetDbimage()
        {
            return await _context.Dbimage.ToListAsync();
        }

        // GET: api/Dbimages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbimage>> GetDbimage(int id)
        {
            var dbimage = await _context.Dbimage.FindAsync(id);

            if (dbimage == null)
            {
                return NotFound();
            }

            return dbimage;
        }

        // PUT: api/Dbimages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbimage(int id, Dbimage dbimage)
        {
            if (id != dbimage.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbimage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbimageExists(id))
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

        // POST: api/Dbimages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dbimage>> PostDbimage(Dbimage dbimage)
        {
            _context.Dbimage.Add(dbimage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbimage", new { id = dbimage.Id }, dbimage);
        }

        // DELETE: api/Dbimages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dbimage>> DeleteDbimage(int id)
        {
            var dbimage = await _context.Dbimage.FindAsync(id);
            if (dbimage == null)
            {
                return NotFound();
            }

            _context.Dbimage.Remove(dbimage);
            await _context.SaveChangesAsync();

            return dbimage;
        }

        private bool DbimageExists(int id)
        {
            return _context.Dbimage.Any(e => e.Id == id);
        }
    }
}
