using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly Store _context;

        public CheckController(Store context)
        {
            _context = context;
        }

        // GET: api/Check
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Check>>> GetChecks()
        {
            return await _context.Checks.ToListAsync();
        }

        // GET: api/Check/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Check>> GetChecks(int id)
        {
            var check = await _context.Checks.FindAsync(id);

            if (check == null)
            {
                return NotFound();
            }

            return check;
        }

        // PUT: api/Check/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChecks(int id, Check check)
        {
            if (id != check.CheckId)
            {
                return BadRequest();
            }

            _context.Entry(check).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecksExists(id))
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

        // POST: api/Check
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostChecks(Check check)
        {
            _context.Checks.Add(check);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChecksExists(check.CheckId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChecks", new { id = check.CheckId }, check);
        }

        // DELETE: api/Check/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheck(int id)
        {
            var check = await _context.Checks.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }

            _context.Checks.Remove(check);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChecksExists(int id)
        {
            return _context.Checks.Any(e => e.CheckId == id);
        }
    }
}
