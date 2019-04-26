using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace  CaseStudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        /**
         * get everything
         * */
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult<IEnumerable<string>> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/<<id>>
        /**
         * the ID is passed through the URL
         * and this is passed to this controller
         * and used to get the data
         */
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        /**
         * Use POST for inserts
         * */
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/<<id>>
        /**
         * use PUT for updates, providing id
         * */
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/<<id>>
        /**
         * 
         * delete something, obviously 
         */
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public void Delete(int id)
        {
        }
    }
}
