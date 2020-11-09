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
    public class ImportInvoicesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public ImportInvoicesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ImportInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportInvoice>>> GetImportInvoice()
        {
            return await _context.ImportInvoice.ToListAsync();
        }

        // GET: api/ImportInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportInvoice>> GetImportInvoice(string id)
        {
            var importInvoice = await _context.ImportInvoice.FindAsync(id);

            if (importInvoice == null)
            {
                return NotFound();
            }

            return importInvoice;
        }

        // PUT: api/ImportInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportInvoice(string id, ImportInvoice importInvoice)
        {
            if (id != importInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(importInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportInvoiceExists(id))
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

        // POST: api/ImportInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ImportInvoice>> PostImportInvoice(ImportInvoice importInvoice)
        {
            _context.ImportInvoice.Add(importInvoice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImportInvoiceExists(importInvoice.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImportInvoice", new { id = importInvoice.Id }, importInvoice);
        }

        // DELETE: api/ImportInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportInvoice>> DeleteImportInvoice(string id)
        {
            var importInvoice = await _context.ImportInvoice.FindAsync(id);
            if (importInvoice == null)
            {
                return NotFound();
            }

            _context.ImportInvoice.Remove(importInvoice);
            await _context.SaveChangesAsync();

            return importInvoice;
        }

        private bool ImportInvoiceExists(string id)
        {
            return _context.ImportInvoice.Any(e => e.Id == id);
        }
    }
}
