using LogInAuthService.Data;
using LogInAuthService.Models;
using LogInAuthService.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<User>>> GetRegistrationMV()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Registration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetRegistrationMV(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
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
        public async Task<ActionResult<User>> PostRegistrationMV(RegistrationMV registrationMV)
        {
            var user = new User()
            {
                Username = registrationMV.Username,
                Password = registrationMV.Password
            };
            user.UserDetails = new UserDetails
            {
                UserId = user.Id,
                firstName = registrationMV.firstName,
                lastName = registrationMV.lastName,
                age = registrationMV.age,
                email = registrationMV.Username,
                roles = registrationMV.roles
            };
            user.Address = new Address
            {
                UserId = user.Id,
                street = registrationMV.Street,
                city = registrationMV.City,
                state = registrationMV.State,
                zipcode = registrationMV.ZipCode,
                country = registrationMV.Country
            };
            user.AccountDetails = new AccountDetails
            {
                UserId = user.Id,
                accountNumber = registrationMV.accountNumber,
                bankName = registrationMV.bankName,
                bankCode = registrationMV.bankCode,
                branch = registrationMV.branch,
                ifscCode = registrationMV.ifscCode,
                upiId = registrationMV.upiId,
                dateOfExpiry = registrationMV.dateOfExpiry,
                accountType = registrationMV.accountType,
                nominee = registrationMV.nominee,
                relationWithNominee = registrationMV.relationWithNominee,
                isActive = registrationMV.isActive,
                balance = registrationMV.balance
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

                       return CreatedAtAction("GetRegistrationMV", new { id = user.Id }, User);
        }

        // DELETE: api/Registration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationMV(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrationMVExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
