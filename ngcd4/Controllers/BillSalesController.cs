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
    public class BillSalesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public BillSalesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/BillSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillSale>>> GetBillSale()
        {
            return await _context.BillSale.ToListAsync();
        }

        // GET: api/BillSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillSale>> GetBillSale(string id)
        {
            var billSale = await _context.BillSale.FindAsync(id);

            if (billSale == null)
            {
                return NotFound();
            }

            return billSale;
        }

        // PUT: api/BillSales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillSale(string id, BillSale billSale)
        {
            if (id != billSale.Id)
            {
                return BadRequest();
            }

            _context.Entry(billSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillSaleExists(id))
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

        // POST: api/BillSales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillSale>> PostBillSale(BillSale billSale)
        {
            _context.BillSale.Add(billSale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillSaleExists(billSale.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBillSale", new { id = billSale.Id }, billSale);
        }

        // DELETE: api/BillSales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillSale>> DeleteBillSale(string id)
        {
            var billSale = await _context.BillSale.FindAsync(id);
            if (billSale == null)
            {
                return NotFound();
            }

            _context.BillSale.Remove(billSale);
            await _context.SaveChangesAsync();

            return billSale;
        }

        private bool BillSaleExists(string id)
        {
            return _context.BillSale.Any(e => e.Id == id);
        }
    }
}
