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
    public class CumulativePointsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public CumulativePointsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/CumulativePoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CumulativePoints>>> GetCumulativePoints()
        {
            return await _context.CumulativePoints.ToListAsync();
        }

        // GET: api/CumulativePoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CumulativePoints>> GetCumulativePoints(string id)
        {
            var cumulativePoints = await _context.CumulativePoints.FindAsync(id);

            if (cumulativePoints == null)
            {
                return NotFound();
            }

            return cumulativePoints;
        }

        // PUT: api/CumulativePoints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCumulativePoints(string id, CumulativePoints cumulativePoints)
        {
            if (id != cumulativePoints.Id)
            {
                return BadRequest();
            }

            _context.Entry(cumulativePoints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CumulativePointsExists(id))
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

        // POST: api/CumulativePoints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CumulativePoints>> PostCumulativePoints(CumulativePoints cumulativePoints)
        {
            _context.CumulativePoints.Add(cumulativePoints);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CumulativePointsExists(cumulativePoints.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCumulativePoints", new { id = cumulativePoints.Id }, cumulativePoints);
        }

        // DELETE: api/CumulativePoints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CumulativePoints>> DeleteCumulativePoints(string id)
        {
            var cumulativePoints = await _context.CumulativePoints.FindAsync(id);
            if (cumulativePoints == null)
            {
                return NotFound();
            }

            _context.CumulativePoints.Remove(cumulativePoints);
            await _context.SaveChangesAsync();

            return cumulativePoints;
        }

        private bool CumulativePointsExists(string id)
        {
            return _context.CumulativePoints.Any(e => e.Id == id);
        }
    }
}
