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
    public class PreferencesController : ControllerBase
    {
        private readonly Context _context;

        public PreferencesController(Context context)
        {
            _context = context;
        }

        // GET: api/Preferences
        [HttpGet]
        public IEnumerable<Preference> GetAllPreferences()
        {
            return _context.preferences;
        }

        // GET: api/Preferences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreference([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preference = await _context.preferences.FindAsync(id);

            if (preference == null)
            {
                return NotFound();
            }

            return Ok(preference);
        }

        // PUT: api/Preferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreferences([FromRoute] int id, [FromBody] Preference preference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preference.PreferenceId)
            {
                return BadRequest();
            }

            _context.Entry(preference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenceExists(id))
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

        // POST: api/Preferences
        [HttpPost]
        public async Task<IActionResult> PostPreference([FromBody] Preference preference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.preferences.Add(preference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreference", new { id = preference.PreferenceId }, preference);
        }

        // DELETE: api/Preferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreference([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preference = await _context.preferences.FindAsync(id);
            if (preference == null)
            {
                return NotFound();
            }

            _context.preferences.Remove(preference);
            await _context.SaveChangesAsync();

            return Ok(preference);
        }

        private bool PreferenceExists(int id)
        {
            return _context.preferences.Any(e => e.PreferenceId == id);
        }
    }
}