using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myproject.Models;

namespace Myproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceLoginsController : ControllerBase
    {
        private readonly MyDataBaseContext _context;

        public ServiceLoginsController(MyDataBaseContext context)
        {
            _context = context;
        }

        // GET: api/ServiceLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceLogin>>> GetServiceLogins()
        {
          if (_context.ServiceLogins == null)
          {
              return NotFound();
          }
            return await _context.ServiceLogins.ToListAsync();
        }

        // GET: api/ServiceLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceLogin>> GetServiceLogin(int id)
        {
          if (_context.ServiceLogins == null)
          {
              return NotFound();
          }
            var serviceLogin = await _context.ServiceLogins.FindAsync(id);

            if (serviceLogin == null)
            {
                return NotFound();
            }

            return serviceLogin;
        }

        // PUT: api/ServiceLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceLogin(int id, ServiceLogin serviceLogin)
        {
            if (id != serviceLogin.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceLoginExists(id))
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

        // POST: api/ServiceLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceLogin>> PostServiceLogin(ServiceLogin serviceLogin)
        {
          if (_context.ServiceLogins == null)
          {
              return Problem("Entity set 'MyDataBaseContext.ServiceLogins'  is null.");
          }
            _context.ServiceLogins.Add(serviceLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceLogin", new { id = serviceLogin.Id }, serviceLogin);
        }

        // DELETE: api/ServiceLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceLogin(int id)
        {
            if (_context.ServiceLogins == null)
            {
                return NotFound();
            }
            var serviceLogin = await _context.ServiceLogins.FindAsync(id);
            if (serviceLogin == null)
            {
                return NotFound();
            }

            _context.ServiceLogins.Remove(serviceLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceLoginExists(int id)
        {
            return (_context.ServiceLogins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
