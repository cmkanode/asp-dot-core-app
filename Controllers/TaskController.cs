using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using cmkService.Models;

namespace cmkService.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        public TaskController(ITaskRepository tasks){
            Tasks = tasks;
        }
        public ITaskRepository Tasks { get; set; }

        [HttpGet("[action]")]
        public IEnumerable<Task> GetAll()
        {
            return Tasks.GetAll();
        }

        [HttpGet("GetTask/{id}")]
        [HttpGet("{id}", Name = "GetTask")] // The name is not being recognized.
        public IActionResult GetById(int id)
        {
            var task = Tasks.Find(id);
            if(task == null){
                Console.WriteLine("Contact not found.");
                return NotFound();
            }
            return new ObjectResult(task);
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Task contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            Tasks.Add(contact);
            return CreatedAtRoute(routeName: "GetTask", routeValues: new { id = contact.Id }, value: contact); 
            // CreatedAtRoute is sending user to api/Contact/[guid].  It's not picking up the route name.
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Update(int id, [FromBody] Task task)
        {
            if(task == null || task.Id != id)
            {
                return BadRequest();
            }

            var ct = Tasks.Find(id);
            if(ct == null)
            {
                return NotFound();
            }

            Tasks.Update(task);
            return new NoContentResult();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var task = Tasks.Find(id);
            if (task == null )
            {
                return NotFound();
            }

            Tasks.Remove(id);
            return new NoContentResult();
        }
    }
}