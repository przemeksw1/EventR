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
    public class UzytkowniciesController : ControllerBase
    {
        private readonly Context _context;

        public UzytkowniciesController(Context context)
        {
            _context = context;
        }

        // GET: api/Uzytkownicies
        [HttpGet]
        public IEnumerable<Uzytkownicy> Getuzytkownicy()
        {
            return _context.uzytkownicy;
        }

        // GET: api/Uzytkownicies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUzytkownicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uzytkownicy = await _context.uzytkownicy.FindAsync(id);

            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return Ok(uzytkownicy);
        }

        // PUT: api/Uzytkownicies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUzytkownicy([FromRoute] int id, [FromBody] Uzytkownicy uzytkownicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uzytkownicy.Id_Uytkownika)
            {
                return BadRequest();
            }

            _context.Entry(uzytkownicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzytkownicyExists(id))
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

        // POST: api/Uzytkownicies
        [HttpPost]
        public async Task<IActionResult> PostUzytkownicy([FromBody] Uzytkownicy uzytkownicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.uzytkownicy.Add(uzytkownicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUzytkownicy", new { id = uzytkownicy.Id_Uytkownika }, uzytkownicy);
        }

        // DELETE: api/Uzytkownicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUzytkownicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uzytkownicy = await _context.uzytkownicy.FindAsync(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            _context.uzytkownicy.Remove(uzytkownicy);
            await _context.SaveChangesAsync();

            return Ok(uzytkownicy);
        }

        private bool UzytkownicyExists(int id)
        {
            return _context.uzytkownicy.Any(e => e.Id_Uytkownika == id);
        }
    }
}