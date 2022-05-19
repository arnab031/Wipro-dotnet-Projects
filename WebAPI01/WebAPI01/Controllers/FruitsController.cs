using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI01.Controllers
{
    [Route("api/[controller]")]
    public class FruitsController : Controller
    {
        static List<string> fruits = new List<string>() { "Apple", "Banana", "Grapes", "Cherry", "Orange" };
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return fruits;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return fruits[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            fruits.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            fruits[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fruits.RemoveAt(id);
        }
    }
}

