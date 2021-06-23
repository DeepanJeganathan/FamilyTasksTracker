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
    public class PersonController : ControllerBase
    {
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            this._person = person;
        }

        // GET: api/Person
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_person.GetAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!_person.Exists(id))
            {
                return NotFound();
            }
            return Ok(_person.Get(id));
        }

        // POST: api/Person
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Person person)
        {
            if (person==null)
            {
                return BadRequest(ModelState);
            }
            if (!await _person.Create(person))
            {
                ModelState.AddModelError("", "there was an error in saving entry");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(Get), new { id = person.PersonId },person);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] Person person)
        {
            if (!_person.Exists(id))
            {
                return NotFound();
            }
            person.PersonId = id;
            if (!await _person.Update(person))
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
            if (!_person.Exists(id))
            {
                return NotFound();
            }
            var person = _person.Get(id);

            if (!await _person.Delete(person))
            {
                ModelState.AddModelError("", "error in deleting person");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
