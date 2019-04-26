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
    public class EngagementModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EngagementModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EngagementModels
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<EngagementModel> GetEngagementModels()
        {
            return _context.EngagementModels;
        }

        // GET: api/EngagementModels/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetEngagementModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var engagementModel = await _context.EngagementModels.FindAsync(id);

            if (engagementModel == null)
            {
                return NotFound();
            }

            return Ok(engagementModel);
        }

        // PUT: api/EngagementModels/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutEngagementModel([FromRoute] int id, [FromBody] EngagementModel engagementModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != engagementModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(engagementModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngagementModelExists(id))
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

        // POST: api/EngagementModels
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostEngagementModel([FromBody] EngagementModel engagementModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EngagementModels.Add(engagementModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEngagementModel", new { id = engagementModel.Id }, engagementModel);
        }

        // DELETE: api/EngagementModels/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteEngagementModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var engagementModel = await _context.EngagementModels.FindAsync(id);
            if (engagementModel == null)
            {
                return NotFound();
            }

            _context.EngagementModels.Remove(engagementModel);
            await _context.SaveChangesAsync();

            return Ok(engagementModel);
        }

        private bool EngagementModelExists(int id)
        {
            return _context.EngagementModels.Any(e => e.Id == id);
        }
    }
}