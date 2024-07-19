using Microsoft.AspNetCore.Mvc;
using SimpleRestApi.Entities;
using SimpleRestApi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerService;
        readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this._customerService = customerService;
            this._logger = logger;
        }
        

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            _logger.LogInformation("Showing list of customers");
            return Ok(_customerService.GetAllCustomers());
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            _customerService.CreateNewCustomer(customer);
            _logger.LogInformation("Created new customer");
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(id);
            _logger.LogInformation("deleted");
            return NoContent();
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}