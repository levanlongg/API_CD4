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
    public class NewsTypesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public NewsTypesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/NewsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsType>>> GetNewsType()
        {
            return await _context.NewsType.ToListAsync();
        }

        // GET: api/NewsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsType>> GetNewsType(string id)
        {
            var newsType = await _context.NewsType.FindAsync(id);

            if (newsType == null)
            {
                return NotFound();
            }

            return newsType;
        }

        // PUT: api/NewsTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsType(string id, NewsType newsType)
        {
            if (id != newsType.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsTypeExists(id))
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

        // POST: api/NewsTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NewsType>> PostNewsType(NewsType newsType)
        {
            _context.NewsType.Add(newsType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewsTypeExists(newsType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewsType", new { id = newsType.Id }, newsType);
        }

        // DELETE: api/NewsTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsType>> DeleteNewsType(string id)
        {
            var newsType = await _context.NewsType.FindAsync(id);
            if (newsType == null)
            {
                return NotFound();
            }

            _context.NewsType.Remove(newsType);
            await _context.SaveChangesAsync();

            return newsType;
        }

        private bool NewsTypeExists(string id)
        {
            return _context.NewsType.Any(e => e.Id == id);
        }
    }
}
