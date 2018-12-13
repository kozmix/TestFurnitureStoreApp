using FurnitureStoreWebApp.Data;
using FurnitureStoreWebApp.Models;
using FurnitureStoreWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LokoFurnitureSoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly IGenericRepository<Customer> _customerRepository;

        public CustomersController(IGenericRepository<Customer> repository)
        {
            _customerRepository = repository;
        }

        [HttpGet()]
        public IActionResult GetCustomers()
        {
            List<Customer> customers = _customerRepository.GetEntities().ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerRepository.GetEntity(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost("create")]
        public IActionResult CreateCustomer([FromBody]Customer newCustomer)
        {
            if (newCustomer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_customerRepository.EntityExists(newCustomer.Name))
            {
                return new JsonResult("customerExists");
            }

            _customerRepository.AddEntity(newCustomer);
            if (!_customerRepository.Save()) { 
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(newCustomer);
        }
    }
}
