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
    public class TasksToDoController : ControllerBase
    {
        private readonly ITaskToDo _taskToDo;

        public TasksToDoController(ITaskToDo taskToDo)
        {
            this._taskToDo = taskToDo;
        }
        // GET: api/TasksToDo
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_taskToDo.GetAll());
        }

        // GET: api/TasksToDo/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!_taskToDo.Exists(id))
            {
                return NotFound();
            }
            return Ok(_taskToDo.Get(id));
        }

        // POST: api/TasksToDo
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] TaskToDo taskToDo)
        {
            if (taskToDo==null)
            {
                ModelState.AddModelError("", " invalid fields ");
                return BadRequest(ModelState);
            }
            if (! await _taskToDo.Create(taskToDo))
            {
                ModelState.AddModelError("", "error in saving data");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(Get), new { id = taskToDo.TaskToDoId }, taskToDo);
        }

        // PUT: api/TasksToDo/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] TaskToDo taskToDo)
        {
            if (!_taskToDo.Exists(taskToDo.TaskToDoId))
            {
                return NotFound();
            }

            if (!await _taskToDo.Update(taskToDo))
            {
                ModelState.AddModelError("", "error in  updating entery");
                return StatusCode(500, ModelState); 
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete(int id)
        {
            if (!_taskToDo.Exists(id))
            {
                return NotFound();
            }
            var item = _taskToDo.Get(id);
            if (!await _taskToDo.Delete(item))
            {
                ModelState.AddModelError("", "error in deleting task");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
