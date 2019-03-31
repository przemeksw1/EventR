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
    public class EventsController : ControllerBase
    {
        private readonly Context _context;

        public EventsController(Context context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.events;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var events = await _context.events.FindAsync(id);

            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Event _event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _event.EventId)
            {
                return BadRequest();
            }

            _context.Entry(_event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event _event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.events.Add(_event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = _event.EventId }, _event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var events = await _context.events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }

            _context.events.Remove(events);
            await _context.SaveChangesAsync();

            return Ok(events);
        }

        private bool EventExists(int id)
        {
            return _context.events.Any(e => e.EventId == id);
        }
    }
}