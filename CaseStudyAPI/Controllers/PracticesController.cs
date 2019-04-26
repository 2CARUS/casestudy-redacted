using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using  CaseStudyAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace  CaseStudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticesController : ControllerBase
    {
        private ApplicationDbContext _context;

        public PracticesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Practices
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Practice> GetPractices()
        {
            return _context.Practices;
        }

        // GET: api/Practices/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetPractice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var practice = await _context.Practices.FindAsync(id);

            if (practice == null)
            {
                return NotFound();
            }

            return Ok(practice);
        }

        // PUT: api/Practices/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutPractice([FromRoute] int id, [FromBody] Practice practice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != practice.Id)
            {
                return BadRequest();
            }

            _context.Entry(practice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracticeExists(id))
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
        // /**
        //  * So as not to cause irrepairable damage, creating an alternate Post method
        //  */
        // // POST: api/Practices
        // [HttpPost]
        // public async void PostPractice([FromBody] JObject value)
        // {
        //     //if (!ModelState.IsValid)
        //     //{
        //     //    return BadRequest(ModelState);
        //     //}
        //     Practice practice = value.ToObject<Practice>();

        //     _context.Practices.Add(practice);
        //     await _context.SaveChangesAsync();
        // }

        // POST: api/Practices
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostPractice([FromBody] Practice practice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Practices.Add(practice);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPractice", new { id = practice.Id }, practice);
        }

        // DELETE: api/Practices/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeletePractice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var practice = await _context.Practices.FindAsync(id);
            if (practice == null)
            {
                return NotFound();
            }

            _context.Practices.Remove(practice);
            await _context.SaveChangesAsync();

            return Ok(practice);
        }

        private bool PracticeExists(int id)
        {
            return _context.Practices.Any(e => e.Id == id);
        }
    }
}