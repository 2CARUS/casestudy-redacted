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
    public class CaseStudiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CaseStudiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseStudies
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<CaseStudy> GetCaseStudies()
        {
            return _context.CaseStudies;
        }

        // GET: api/CaseStudies/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCaseStudy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseStudy = await _context.CaseStudies.FindAsync(id);

            if (caseStudy == null)
            {
                return NotFound();
            }

            return Ok(caseStudy);
        }

        // PUT: api/CaseStudies/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutCaseStudy([FromRoute] int id, [FromBody] CaseStudy caseStudy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseStudy.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseStudy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseStudyExists(id))
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

        // POST: api/CaseStudies
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostCaseStudy([FromBody] CaseStudy caseStudy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CaseStudies.Add(caseStudy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseStudy", new { id = caseStudy.Id }, caseStudy);
        }

        // DELETE: api/CaseStudies/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteCaseStudy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseStudy = await _context.CaseStudies.FindAsync(id);
            if (caseStudy == null)
            {
                return NotFound();
            }

            _context.CaseStudies.Remove(caseStudy);
            await _context.SaveChangesAsync();

            return Ok(caseStudy);
        }

        private bool CaseStudyExists(int id)
        {
            return _context.CaseStudies.Any(e => e.Id == id);
        }
    }
}