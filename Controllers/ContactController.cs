using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using cmkService.Models;

namespace cmkService.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        public ContactController(IContactRepository contacts){
            Contacts = contacts;
        }
        public IContactRepository Contacts { get; set; }

        [HttpGet("[action]")]
        public IEnumerable<Contact> GetAll()
        {
            return Contacts.GetAll();
        }

        [HttpGet("GetContact/{id}")]
        [HttpGet("{id}", Name = "GetContact")] // The name is not being recognized.
        public IActionResult GetById(Guid id)
        {
            var contact = Contacts.Find(id);
            if(contact == null){
                Console.WriteLine("Contact not found.");
                return NotFound();
            }
            return new ObjectResult(contact);
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            Contacts.Add(contact);
            return CreatedAtRoute(routeName: "GetContact", routeValues: new { id = contact.Id }, value: contact); 
            // CreatedAtRoute is sending user to api/Contact/[guid].  It's not picking up the route name.
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Update(Guid id, [FromBody] Contact contact)
        {
            if(contact == null || contact.Id != id)
            {
                return BadRequest();
            }

            var ct = Contacts.Find(id);
            if(ct == null)
            {
                return NotFound();
            }

            Contacts.Update(contact);
            return new NoContentResult();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(Guid id)
        {
            var contact = Contacts.Find(id);
            if (contact == null )
            {
                return NotFound();
            }

            Contacts.Remove(id);
            return new NoContentResult();
        }
    }
}