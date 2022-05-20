using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        CustomerBO context = new CustomerBO();
        // GET: api/values
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return context.GetCustomers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public CustomerModel Get(int id)
        {
            return context.GetCustomerById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]CustomerModel value)
        {
            context.AddCustomer(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CustomerModel value)
        {
            context.EditCustomerById(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.DeleteCustomerById(id);
        }
    }
}

