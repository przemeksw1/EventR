using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventRApi.Models;
using EventR.ViewModels;
using EventR.Services;
using Microsoft.AspNetCore.Authorization;

namespace EventR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IEventService _eventService;

        public EventsController(Context context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }



        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.events;
        }

        // GET: api/Events/5
        // Po iD wyszukiwanie.
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
        [Route("api/Events/{id}")]
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

        // POST: api/Events/Add
        [HttpPost]
        [Route("api/Events/Add")]
        public IActionResult Add([FromBody] EventViewModel eventViewModel)
        {
            try
            {
                _eventService.AddEvent(eventViewModel);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        [Route("api/Events/{id}")]
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

        [HttpPut("{id}"), Authorize]        
        public async Task<IActionResult> AddToObservable([FromForm] int id)
        {
            var email = User.Identity.Name;
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if (user == null)
                return BadRequest();
            var eve = _context.events.SingleOrDefault(u => u.AuthorId == id);
            if (eve == null)
                return BadRequest();
            user.ObservatedEvents.Add(eve);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> LikeEvent([FromForm] int id)
        {
            var email = User.Identity.Name;
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if (user == null)
                return BadRequest();
            var eve = _context.events.SingleOrDefault(u => u.AuthorId == id);
            if (eve == null)
                return BadRequest();
            user.LikedEvents.Add(eve);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> RemoveFromObservable([FromForm] int id)
        {
            var email = User.Identity.Name;
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if (user == null)
                return BadRequest();
            var eve = _context.events.SingleOrDefault(u => u.AuthorId == id);
            if (eve == null)
                return BadRequest();
            user.ObservatedEvents.Remove(eve);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UnlikeEvent([FromForm] int id)
        {
            var email = User.Identity.Name;
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if (user == null)
                return BadRequest();
            var eve = _context.events.SingleOrDefault(u => u.AuthorId == id);
            if (eve == null)
                return BadRequest();
            user.LikedEvents.Remove(eve);
            await _context.SaveChangesAsync();
            return Ok(user);
        }


        private bool EventExists(int id)
        {
            return _context.events.Any(e => e.EventId == id);
        }
    }
}