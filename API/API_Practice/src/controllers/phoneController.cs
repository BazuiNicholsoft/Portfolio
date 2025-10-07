using API_Practice.src.models.ControllerModels;
using API_Practice.src.services;
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.src.controllers
{
    public class PhoneController
    {
        public PhoneService _phoneService;

        public PhoneController()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("database")
                .Options;
            var databaseContext = new DatabaseContext(options);
            _phoneService = new PhoneService(databaseContext);
        }

        [HttpGet("/phones")]
        public List<Phone> GetAllPhones()
        {
            return _phoneService.GetAllPhones();
        }

        [HttpGet("/phones/{id}")]
        public Phone? GetPhoneById(int id)
        {
            return _phoneService.GetPhoneById(id);
        }

        [HttpPost("/customers/{customerId}/phones")]
        public Phone CreatePhone(int customerId, Phone phone)
        {
            return _phoneService.CreatePhone(phone, customerId);
        }

        [HttpPut("/phones/{id}")]
        public Phone? UpdatePhone(int id, Phone updatedPhone)
        {
            return _phoneService.UpdatePhone(id, updatedPhone);
        }

        [HttpDelete("/phones/{id}")]
        public bool DeletePhone(int id)
        {
            return _phoneService.DeletePhone(id);
        }
    }
}