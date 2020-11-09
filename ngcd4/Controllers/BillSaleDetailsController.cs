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
    public class BillSaleDetailsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public BillSaleDetailsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/BillSaleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillSaleDetail>>> GetBillSaleDetail()
        {
            return await _context.BillSaleDetail.ToListAsync();
        }

        // GET: api/BillSaleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillSaleDetail>> GetBillSaleDetail(string id)
        {
            var billSaleDetail = await _context.BillSaleDetail.FindAsync(id);

            if (billSaleDetail == null)
            {
                return NotFound();
            }

            return billSaleDetail;
        }

        // PUT: api/BillSaleDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillSaleDetail(string id, BillSaleDetail billSaleDetail)
        {
            if (id != billSaleDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(billSaleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillSaleDetailExists(id))
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

        // POST: api/BillSaleDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillSaleDetail>> PostBillSaleDetail(BillSaleDetail billSaleDetail)
        {
            _context.BillSaleDetail.Add(billSaleDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillSaleDetailExists(billSaleDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBillSaleDetail", new { id = billSaleDetail.Id }, billSaleDetail);
        }

        // DELETE: api/BillSaleDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillSaleDetail>> DeleteBillSaleDetail(string id)
        {
            var billSaleDetail = await _context.BillSaleDetail.FindAsync(id);
            if (billSaleDetail == null)
            {
                return NotFound();
            }

            _context.BillSaleDetail.Remove(billSaleDetail);
            await _context.SaveChangesAsync();

            return billSaleDetail;
        }

        private bool BillSaleDetailExists(string id)
        {
            return _context.BillSaleDetail.Any(e => e.Id == id);
        }
    }
}
