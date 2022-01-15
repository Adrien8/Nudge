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
    public class DefiApiController : ControllerBase
    {
        private readonly NudgeContext _context;

        public DefiApiController(NudgeContext context)
        {
            _context = context;
        }

        // GET: api/DefiApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Defi>>> GetDefi()
        {
            return await _context.Defi.ToListAsync();
        }

        // GET: api/DefiApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Defi>> GetDefi(int id)
        {
            var defi = await _context.Defi.FindAsync(id);

            if (defi == null)
            {
                return NotFound();
            }

            return defi;
        }

        // PUT: api/DefiApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefi(int id, Defi defi)
        {
            if (id != defi.Id)
            {
                return BadRequest();
            }

            _context.Entry(defi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefiExists(id))
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

        // POST: api/DefiApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Defi>> PostDefi(Defi defi)
        {
            _context.Defi.Add(defi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefi", new { id = defi.Id }, defi);
        }

        // DELETE: api/DefiApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefi(int id)
        {
            var defi = await _context.Defi.FindAsync(id);
            if (defi == null)
            {
                return NotFound();
            }

            _context.Defi.Remove(defi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DefiExists(int id)
        {
            return _context.Defi.Any(e => e.Id == id);
        }
    }
}
