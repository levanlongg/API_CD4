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
    public class ImportInvoiceDetailsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public ImportInvoiceDetailsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ImportInvoiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportInvoiceDetail>>> GetImportInvoiceDetail()
        {
            return await _context.ImportInvoiceDetail.ToListAsync();
        }

        // GET: api/ImportInvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportInvoiceDetail>> GetImportInvoiceDetail(string id)
        {
            var importInvoiceDetail = await _context.ImportInvoiceDetail.FindAsync(id);

            if (importInvoiceDetail == null)
            {
                return NotFound();
            }

            return importInvoiceDetail;
        }

        // PUT: api/ImportInvoiceDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportInvoiceDetail(string id, ImportInvoiceDetail importInvoiceDetail)
        {
            if (id != importInvoiceDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(importInvoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportInvoiceDetailExists(id))
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

        // POST: api/ImportInvoiceDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ImportInvoiceDetail>> PostImportInvoiceDetail(ImportInvoiceDetail importInvoiceDetail)
        {
            _context.ImportInvoiceDetail.Add(importInvoiceDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImportInvoiceDetailExists(importInvoiceDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImportInvoiceDetail", new { id = importInvoiceDetail.Id }, importInvoiceDetail);
        }

        // DELETE: api/ImportInvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportInvoiceDetail>> DeleteImportInvoiceDetail(string id)
        {
            var importInvoiceDetail = await _context.ImportInvoiceDetail.FindAsync(id);
            if (importInvoiceDetail == null)
            {
                return NotFound();
            }

            _context.ImportInvoiceDetail.Remove(importInvoiceDetail);
            await _context.SaveChangesAsync();

            return importInvoiceDetail;
        }

        private bool ImportInvoiceDetailExists(string id)
        {
            return _context.ImportInvoiceDetail.Any(e => e.Id == id);
        }
    }
}
