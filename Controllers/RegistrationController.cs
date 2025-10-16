using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogInAuthService.Data;
using LogInAuthService.ModelView;

namespace LogInAuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserDBContext _context;

        public RegistrationController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/Registration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationMV>>> GetRegistrationMV()
        {
            return await _context.RegistrationMV.ToListAsync();
        }

        // GET: api/Registration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationMV>> GetRegistrationMV(int id)
        {
            var registrationMV = await _context.RegistrationMV.FindAsync(id);

            if (registrationMV == null)
            {
                return NotFound();
            }

            return registrationMV;
        }

        // PUT: api/Registration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationMV(int id, RegistrationMV registrationMV)
        {
            if (id != registrationMV.Id)
            {
                return BadRequest();
            }

            _context.Entry(registrationMV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationMVExists(id))
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

        // POST: api/Registration
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistrationMV>> PostRegistrationMV(RegistrationMV registrationMV)
        {
            _context.RegistrationMV.Add(registrationMV);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrationMV", new { id = registrationMV.Id }, registrationMV);
        }

        // DELETE: api/Registration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationMV(int id)
        {
            var registrationMV = await _context.RegistrationMV.FindAsync(id);
            if (registrationMV == null)
            {
                return NotFound();
            }

            _context.RegistrationMV.Remove(registrationMV);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrationMVExists(int id)
        {
            return _context.RegistrationMV.Any(e => e.Id == id);
        }
    }
}
