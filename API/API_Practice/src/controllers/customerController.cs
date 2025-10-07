using API_Practice.src.services;
using API_Practice.src.models.ControllerModels;
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.src.controllers
{
    public class CustomerController
    {
        public CustomerService _customerService;

        public CustomerController()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("database")
                .Options;
            var databaseContext = new DatabaseContext(options);
            _customerService = new CustomerService(databaseContext);
        }

        [HttpGet("/customers")]
        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("/customers/{id}")]
        public Customer? GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        [HttpPost("/customers")]
        public Customer CreateCustomer(Customer customer)
        {
            return _customerService.CreateCustomer(customer);
        }

        [HttpPut("/customers/{id}")]
        public Customer? UpdateCustomer(int id, Customer updatedCustomer)
        {
            return _customerService.UpdateCustomer(id, updatedCustomer);
        }

        [HttpDelete("/customers/{id}")]
        public bool DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);
        }
    }
}