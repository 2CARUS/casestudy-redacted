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
    public class StaffingDeliveryModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffingDeliveryModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffingDeliveryModels
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IEnumerable<StaffingDeliveryModel> GetStaffingDeliveryModels()
        {
            return _context.StaffingDeliveryModels;
        }

        // GET: api/StaffingDeliveryModels/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetStaffingDeliveryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffingDeliveryModel = await _context.StaffingDeliveryModels.FindAsync(id);

            if (staffingDeliveryModel == null)
            {
                return NotFound();
            }

            return Ok(staffingDeliveryModel);
        }

        // PUT: api/StaffingDeliveryModels/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutStaffingDeliveryModel([FromRoute] int id, [FromBody] StaffingDeliveryModel staffingDeliveryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffingDeliveryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffingDeliveryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffingDeliveryModelExists(id))
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

        // POST: api/StaffingDeliveryModels
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostStaffingDeliveryModel([FromBody] StaffingDeliveryModel staffingDeliveryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffingDeliveryModels.Add(staffingDeliveryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffingDeliveryModel", new { id = staffingDeliveryModel.Id }, staffingDeliveryModel);
        }

        // DELETE: api/StaffingDeliveryModels/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteStaffingDeliveryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffingDeliveryModel = await _context.StaffingDeliveryModels.FindAsync(id);
            if (staffingDeliveryModel == null)
            {
                return NotFound();
            }

            _context.StaffingDeliveryModels.Remove(staffingDeliveryModel);
            await _context.SaveChangesAsync();

            return Ok(staffingDeliveryModel);
        }

        private bool StaffingDeliveryModelExists(int id)
        {
            return _context.StaffingDeliveryModels.Any(e => e.Id == id);
        }
    }
}