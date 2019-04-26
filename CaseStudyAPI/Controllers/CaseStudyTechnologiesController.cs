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
    public class CaseStudyTechnologiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CaseStudyTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseStudyTechnologies
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<CaseStudyTechnology> GetCaseStudyTechnologies()
        {
            return _context.CaseStudyTechnologies;
        }

        // GET: api/CaseStudyTechnologies/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCaseStudyTechnology([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseStudyTechnology = await _context.CaseStudyTechnologies.FindAsync(id);

            if (caseStudyTechnology == null)
            {
                return NotFound();
            }

            return Ok(caseStudyTechnology);
        }

        // PUT: api/CaseStudyTechnologies/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutCaseStudyTechnology([FromRoute] int id, [FromBody] CaseStudyTechnology caseStudyTechnology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseStudyTechnology.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseStudyTechnology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseStudyTechnologyExists(id))
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

        // POST: api/CaseStudyTechnologies
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostCaseStudyTechnology([FromBody] CaseStudyTechnology caseStudyTechnology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CaseStudyTechnologies.Add(caseStudyTechnology);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseStudyTechnology", new { id = caseStudyTechnology.Id }, caseStudyTechnology);
        }

        // DELETE: api/CaseStudyTechnologies/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteCaseStudyTechnology([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseStudyTechnology = await _context.CaseStudyTechnologies.FindAsync(id);
            if (caseStudyTechnology == null)
            {
                return NotFound();
            }

            _context.CaseStudyTechnologies.Remove(caseStudyTechnology);
            await _context.SaveChangesAsync();

            return Ok(caseStudyTechnology);
        }

        private bool CaseStudyTechnologyExists(int id)
        {
            return _context.CaseStudyTechnologies.Any(e => e.Id == id);
        }
    }
}