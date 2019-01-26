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
    public class GrafikisController : ControllerBase
    {
        private readonly Context _context;

        public GrafikisController(Context context)
        {
            _context = context;
        }

        // GET: api/Grafikis
        [HttpGet]
        public IEnumerable<Grafiki> Getgrafiki()
        {
            return _context.grafiki;
        }

        // GET: api/Grafikis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrafiki([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grafiki = await _context.grafiki.FindAsync(id);

            if (grafiki == null)
            {
                return NotFound();
            }

            return Ok(grafiki);
        }

        // PUT: api/Grafikis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrafiki([FromRoute] int id, [FromBody] Grafiki grafiki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grafiki.Id_Grafiki)
            {
                return BadRequest();
            }

            _context.Entry(grafiki).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrafikiExists(id))
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

        // POST: api/Grafikis
        [HttpPost]
        public async Task<IActionResult> PostGrafiki([FromBody] Grafiki grafiki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.grafiki.Add(grafiki);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrafiki", new { id = grafiki.Id_Grafiki }, grafiki);
        }

        // DELETE: api/Grafikis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrafiki([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grafiki = await _context.grafiki.FindAsync(id);
            if (grafiki == null)
            {
                return NotFound();
            }

            _context.grafiki.Remove(grafiki);
            await _context.SaveChangesAsync();

            return Ok(grafiki);
        }

        private bool GrafikiExists(int id)
        {
            return _context.grafiki.Any(e => e.Id_Grafiki == id);
        }
    }
}