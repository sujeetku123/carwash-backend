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
    public class CarserviceFeedbacksController : ControllerBase
    {
        private readonly MyDataBaseContext _context;

        public CarserviceFeedbacksController(MyDataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CarserviceFeedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarserviceFeedback>>> GetCarserviceFeedbacks()
        {
          if (_context.CarserviceFeedbacks == null)
          {
              return NotFound();
          }
            return await _context.CarserviceFeedbacks.ToListAsync();
        }

        // GET: api/CarserviceFeedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarserviceFeedback>> GetCarserviceFeedback(int id)
        {
          if (_context.CarserviceFeedbacks == null)
          {
              return NotFound();
          }
            var carserviceFeedback = await _context.CarserviceFeedbacks.FindAsync(id);

            if (carserviceFeedback == null)
            {
                return NotFound();
            }

            return carserviceFeedback;
        }

        // PUT: api/CarserviceFeedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarserviceFeedback(int id, CarserviceFeedback carserviceFeedback)
        {
            if (id != carserviceFeedback.FeedbackId)
            {
                return BadRequest();
            }

            _context.Entry(carserviceFeedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarserviceFeedbackExists(id))
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

        // POST: api/CarserviceFeedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarserviceFeedback>> PostCarserviceFeedback(CarserviceFeedback carserviceFeedback)
        {
          if (_context.CarserviceFeedbacks == null)
          {
              return Problem("Entity set 'MyDataBaseContext.CarserviceFeedbacks'  is null.");
          }
            _context.CarserviceFeedbacks.Add(carserviceFeedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarserviceFeedback", new { id = carserviceFeedback.FeedbackId }, carserviceFeedback);
        }

        // DELETE: api/CarserviceFeedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarserviceFeedback(int id)
        {
            if (_context.CarserviceFeedbacks == null)
            {
                return NotFound();
            }
            var carserviceFeedback = await _context.CarserviceFeedbacks.FindAsync(id);
            if (carserviceFeedback == null)
            {
                return NotFound();
            }

            _context.CarserviceFeedbacks.Remove(carserviceFeedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarserviceFeedbackExists(int id)
        {
            return (_context.CarserviceFeedbacks?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
        }
    }
}
