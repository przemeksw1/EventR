using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventRApi.Models;

namespace EventR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencjesController : ControllerBase
    {
        private readonly Context _context;

        public PreferencjesController(Context context)
        {
            _context = context;
        }

        // GET: api/Preferencjes
        [HttpGet]
        public IEnumerable<Preferencje> Getpreferencje()
        {
            return _context.preferencje;
        }

        // GET: api/Preferencjes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreferencje([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preferencje = await _context.preferencje.FindAsync(id);

            if (preferencje == null)
            {
                return NotFound();
            }

            return Ok(preferencje);
        }

        // PUT: api/Preferencjes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreferencje([FromRoute] int id, [FromBody] Preferencje preferencje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preferencje.Id_Preferencji)
            {
                return BadRequest();
            }

            _context.Entry(preferencje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferencjeExists(id))
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

        // POST: api/Preferencjes
        [HttpPost]
        public async Task<IActionResult> PostPreferencje([FromBody] Preferencje preferencje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.preferencje.Add(preferencje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreferencje", new { id = preferencje.Id_Preferencji }, preferencje);
        }

        // DELETE: api/Preferencjes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreferencje([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preferencje = await _context.preferencje.FindAsync(id);
            if (preferencje == null)
            {
                return NotFound();
            }

            _context.preferencje.Remove(preferencje);
            await _context.SaveChangesAsync();

            return Ok(preferencje);
        }

        private bool PreferencjeExists(int id)
        {
            return _context.preferencje.Any(e => e.Id_Preferencji == id);
        }
    }
}