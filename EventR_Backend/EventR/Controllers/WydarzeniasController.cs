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
    public class WydarzeniasController : ControllerBase
    {
        private readonly Context _context;

        public WydarzeniasController(Context context)
        {
            _context = context;
        }

        // GET: api/Wydarzenias
        [HttpGet]
        public IEnumerable<Wydarzenia> Getwydarzenia()
        {
            return _context.wydarzenia;
        }

        // GET: api/Wydarzenias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWydarzenia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var wydarzenia = await _context.wydarzenia.FindAsync(id);

            var wydarzenia = await Task.Run(() => _context.wydarzenia.Where(w => w.Id_Wydarzenia == id).Include(k=>k.Komentarzes));
            if (wydarzenia == null)
            {
                return NotFound();
            }

            return Ok(wydarzenia);
        }

        // PUT: api/Wydarzenias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWydarzenia([FromRoute] int id, [FromBody] Wydarzenia wydarzenia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wydarzenia.Id_Wydarzenia)
            {
                return BadRequest();
            }

            _context.Entry(wydarzenia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WydarzeniaExists(id))
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

        // POST: api/Wydarzenias
        [HttpPost]
        public async Task<IActionResult> PostWydarzenia([FromBody] Wydarzenia wydarzenia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.wydarzenia.Add(wydarzenia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWydarzenia", new { id = wydarzenia.Id_Wydarzenia }, wydarzenia);
        }

        // DELETE: api/Wydarzenias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWydarzenia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wydarzenia = await _context.wydarzenia.FindAsync(id);
            if (wydarzenia == null)
            {
                return NotFound();
            }

            _context.wydarzenia.Remove(wydarzenia);
            await _context.SaveChangesAsync();

            return Ok(wydarzenia);
        }

        private bool WydarzeniaExists(int id)
        {
            return _context.wydarzenia.Any(e => e.Id_Wydarzenia == id);
        }
    }
}