using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApp.Model;
using RestApp.Services;

namespace RestApp.Controllers
{
    
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private IPersonRepository PersonBusiness;
       
        public PersonsController(IPersonRepository personService)
        {
            PersonBusiness = personService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(PersonBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var person = PersonBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) return NotFound();
            return new ObjectResult(PersonBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = PersonBusiness.Update(person);
            if (updatedPerson == null) return BadRequest();

            return new ObjectResult(PersonBusiness.Update(person));
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            PersonBusiness.Delete(id);
            return NoContent();
        }
    }
}
