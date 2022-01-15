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
    public class PersonneApiController : ControllerBase
    {
        private readonly NudgeContext _context;

        public PersonneApiController(NudgeContext context)
        {
            _context = context;
        }

        // GET: api/PersonneApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> GetPersonne()
        {
            return await _context.Personne.ToListAsync();
        }

        // GET: api/PersonneApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personne>> GetPersonne(int id)
        {
            var personne = await _context.Personne.FindAsync(id);

            if (personne == null)
            {
                return NotFound();
            }

            return personne;
        }

        // PUT: api/PersonneApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonne(int id, Personne personne)
        {
            if (id != personne.Id)
            {
                return BadRequest();
            }

            _context.Entry(personne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneExists(id))
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

        // POST: api/PersonneApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personne>> PostPersonne(Personne personne)
        {
            _context.Personne.Add(personne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonne", new { id = personne.Id }, personne);
        }

        // DELETE: api/PersonneApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonne(int id)
        {
            var personne = await _context.Personne.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }

            _context.Personne.Remove(personne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonneExists(int id)
        {
            return _context.Personne.Any(e => e.Id == id);
        }
    }
}
