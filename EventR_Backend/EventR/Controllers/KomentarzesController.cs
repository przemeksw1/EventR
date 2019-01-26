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
    public class KomentarzesController : ControllerBase
    {
        private readonly Context _context;

        public KomentarzesController(Context context)
        {
            _context = context;
        }

        // GET: api/Komentarzes
        [HttpGet]
        public IEnumerable<Komentarze> Getkomentarze()
        {
            return _context.komentarze;
        }

        // GET: api/Komentarzes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKomentarze([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var komentarze = await _context.komentarze.FindAsync(id);

            if (komentarze == null)
            {
                return NotFound();
            }

            return Ok(komentarze);
        }

        // PUT: api/Komentarzes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKomentarze([FromRoute] int id, [FromBody] Komentarze komentarze)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != komentarze.Id_Komentarza)
            {
                return BadRequest();
            }

            _context.Entry(komentarze).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentarzeExists(id))
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

        // POST: api/Komentarzes
        [HttpPost]
        public async Task<IActionResult> PostKomentarze([FromBody] Komentarze komentarze)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.komentarze.Add(komentarze);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKomentarze", new { id = komentarze.Id_Komentarza }, komentarze);
        }

        // DELETE: api/Komentarzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKomentarze([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var komentarze = await _context.komentarze.FindAsync(id);
            if (komentarze == null)
            {
                return NotFound();
            }

            _context.komentarze.Remove(komentarze);
            await _context.SaveChangesAsync();

            return Ok(komentarze);
        }

        private bool KomentarzeExists(int id)
        {
            return _context.komentarze.Any(e => e.Id_Komentarza == id);
        }
    }
}