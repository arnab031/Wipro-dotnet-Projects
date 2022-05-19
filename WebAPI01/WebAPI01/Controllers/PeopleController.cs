using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI01.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        static PersonBO context = new PersonBO();
        // GET: api/values
        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            return context.GetPeople();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PersonModel Get(int id)
        {
            return context.GetPersonById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]PersonModel p1)
        {
            context.AddPerson(p1);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PersonModel p1)
        {
            context.EditPersonById(id, p1);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.DeletePersonById(id);
        }
    }
}

