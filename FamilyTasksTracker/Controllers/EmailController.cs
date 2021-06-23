using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTasksTracker.Model;
using FamilyTasksTracker.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTasksTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmail _email;

        public EmailController(IEmail email)
        {
            this._email = email;
        }

        // GET: api/Email
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_email.GetAll());
        }


        // GET: api/Email/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!_email.Exists(id))
            {
                return NotFound();
            }
            return Ok(_email.Get(id));
        }

        // POST: api/Email
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Email email)
        {
            if (email == null)
            {
                return BadRequest(ModelState);
            }
            if (!await _email.Create(email))
            {
                ModelState.AddModelError("", "there was an error in saving entry");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(Get), new { id = email.EmailId }, email);
        }

        // PUT: api/Email/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] Email email)
        {
            if (!_email.Exists(id))
            {
                return NotFound();
            }
            email.EmailId = id;
            if (!await _email.Update(email))
            {
                ModelState.AddModelError("", "there was an error in updating record");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!_email.Exists(id))
            {
                return NotFound();
            }
            var person = _email.Get(id);

            if (!await _email.Delete(person))
            {
                ModelState.AddModelError("", "error in deleting person");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
