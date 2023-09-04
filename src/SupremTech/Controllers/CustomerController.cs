using Microsoft.AspNetCore.Mvc;
using SupremTech.Domain;
using SupremTech.Repositories.Contracts;

namespace SupremTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        private readonly ILogger _logger;

        public CustomerController(ICustomerRepository customerRepository, ILogger<CustomerController> logger)
        {
            this.customerRepository = customerRepository;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customers = await customerRepository.GetCustomer(id);
            return Ok(customers);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customers customerPayload)
        {
            if (customerPayload == null)
            {
                return BadRequest(); // Invalid customer data
            }

            var result = await customerRepository.AddCustomer(customerPayload);
            return result.Equals("success") ? Ok(new
            {
                message = "Customer Record Added Successfully"
            }) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customers customerPayload)
        {
            if (customerPayload == null)
            {
                return BadRequest(); // Invalid customer data
            }

            var isCustomerexist = await customerRepository.GetCustomer(id);

            if (isCustomerexist == null)
            {
                return NotFound(); // Customer not found
            }
            customerPayload.CustomerID = id;
            var result = await customerRepository.UpdateCustomer(customerPayload);

            return result.Equals("success") ? Ok(new
            {
                message = "Customer Record Updated Successfully"
            }) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var isCustomerexist = await customerRepository.GetCustomer(id);

            if (isCustomerexist == null)
            {
                return NotFound(); // Customer not found
            }

            var result = await customerRepository.DeleteCustomer(isCustomerexist);

            return result.Equals("success") ? Ok(new
            {
                message = "Customer Record Deleted Successfully"
            }) : BadRequest();
        }
    }
}
