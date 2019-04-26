using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  CaseStudyAPI.Models;

namespace  CaseStudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IndustriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Industries
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Industry> GetIndustries()
        {
            return _context.Industries;
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetIndustry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.Industries.FindAsync(id);

            if (industry == null)
            {
                return NotFound();
            }

            return Ok(industry);
        }

        // PUT: api/Industries/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutIndustry([FromRoute] int id, [FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != industry.Id)
            {
                return BadRequest();
            }

            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/Industries
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostIndustry([FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Industries.Add(industry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndustry", new { id = industry.Id }, industry);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteIndustry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();

            return Ok(industry);
        }

        private bool IndustryExists(int id)
        {
            return _context.Industries.Any(e => e.Id == id);
        }
    }
}