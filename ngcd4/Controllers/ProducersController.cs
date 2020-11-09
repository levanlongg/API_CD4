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
    public class ProducersController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public ProducersController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Producers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producer>>> GetProducer()
        {
            return await _context.Producer.ToListAsync();
        }

        // GET: api/Producers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> GetProducer(string id)
        {
            var producer = await _context.Producer.FindAsync(id);

            if (producer == null)
            {
                return NotFound();
            }

            return producer;
        }

        // PUT: api/Producers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducer(string id, Producer producer)
        {
            if (id != producer.Id)
            {
                return BadRequest();
            }

            _context.Entry(producer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducerExists(id))
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

        // POST: api/Producers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Producer>> PostProducer(Producer producer)
        {
            _context.Producer.Add(producer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProducerExists(producer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProducer", new { id = producer.Id }, producer);
        }

        // DELETE: api/Producers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producer>> DeleteProducer(string id)
        {
            var producer = await _context.Producer.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            _context.Producer.Remove(producer);
            await _context.SaveChangesAsync();

            return producer;
        }

        private bool ProducerExists(string id)
        {
            return _context.Producer.Any(e => e.Id == id);
        }
    }
}
