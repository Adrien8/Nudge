using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nudge.Models;

namespace Nudge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TropheeApiController : ControllerBase
    {
        private readonly NudgeContext _context;

        public TropheeApiController(NudgeContext context)
        {
            _context = context;
        }

        // GET: api/TropheeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trophee>>> GetTrophee()
        {
            return await _context.Trophee.ToListAsync();
        }

        // GET: api/TropheeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trophee>> GetTrophee(int id)
        {
            var trophee = await _context.Trophee.FindAsync(id);

            if (trophee == null)
            {
                return NotFound();
            }

            return trophee;
        }

        // PUT: api/TropheeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrophee(int id, Trophee trophee)
        {
            if (id != trophee.Id)
            {
                return BadRequest();
            }

            _context.Entry(trophee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TropheeExists(id))
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

        // POST: api/TropheeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trophee>> PostTrophee(Trophee trophee)
        {
            _context.Trophee.Add(trophee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrophee", new { id = trophee.Id }, trophee);
        }

        // DELETE: api/TropheeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrophee(int id)
        {
            var trophee = await _context.Trophee.FindAsync(id);
            if (trophee == null)
            {
                return NotFound();
            }

            _context.Trophee.Remove(trophee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TropheeExists(int id)
        {
            return _context.Trophee.Any(e => e.Id == id);
        }
    }
}
