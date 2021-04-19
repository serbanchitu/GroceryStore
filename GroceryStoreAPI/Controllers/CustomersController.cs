using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using GroceryStoreAPI.BusinessLogic.Repository;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Controllers
{
   
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomer _repository;

        //inject in constructor - see Startup
        public CustomersController(ICustomer customerRepository)
        {
            _repository = customerRepository;
        }
       
        [HttpGet]
        [Route("api/Customers/getAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var result = _repository.GetAllCustomers();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/customers/getCustomerById/{id}")]
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            //validate
            if (id <= 0) throw new IndexOutOfRangeException("Invalid customer id"); 
            
            var result = _repository.GetCustomerById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/customers/getCustomerNameById/{id}")]
        [HttpGet("{id}")]
        public ActionResult<string> GetCustomerNameById(int id)
        {
            //validate
            if (id <= 0) throw new IndexOutOfRangeException("Invalid customer id");

            var result = _repository.GetCustomerById(id).name;

            if (result == null) 
                return NotFound();

            return Ok(result);
        }
        
 
        [Route("api/customers/addCustomer")]
        [HttpPost]
        public ActionResult<List<Customer>> AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repository.AddCustomer(customer);
            return Ok(result);
        }

        
        [Route("api/customers/updateCustomer")]
        [HttpPut("{id}")]
        public ActionResult<List<Customer>> UpdateCustomer(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = _repository.UpdateCustomer(customer);
            return Ok(result);
        }
    }
}
