using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using  CaseStudyAPI.Models;

namespace  CaseStudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Technologies
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Technology> GetTechnologies()
        {
            return _context.Technologies;
        }

        // GET: api/Technologies/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetTechnology([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technology = await _context.Technologies.FindAsync(id);

            if (technology == null)
            {
                return NotFound();
            }

            return Ok(technology);
        }

        // PUT: api/Technologies/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutTechnology([FromRoute] int id, [FromBody] Technology technology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != technology.Id)
            {
                return BadRequest();
            }

            _context.Entry(technology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnologyExists(id))
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

        // POST: api/Technologies
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostTechnology([FromBody] Technology technology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechnology", new { id = technology.Id }, technology);
        }

        // DELETE: api/Technologies/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteTechnology([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technology = await _context.Technologies.FindAsync(id);
            if (technology == null)
            {
                return NotFound();
            }

            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();

            return Ok(technology);
        }

        private bool TechnologyExists(int id)
        {
            return _context.Technologies.Any(e => e.Id == id);
        }
    }
}