using API_Practice.src.models.ControllerModels;
using API_Practice.src.services;
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.src.controllers
{
    public class AddressController
    {
        public AddressService _addressService;

        public AddressController()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("database")
                .Options;
            var databaseContext = new DatabaseContext(options);
            _addressService = new AddressService(databaseContext);
        }

        [HttpGet("/addresses")]
        public List<Address> GetAllAddresses()
        {
            return _addressService.GetAllAddresses();
        }

        [HttpGet("/addresses/{id}")]
        public Address? GetAddressById(int id)
        {
            return _addressService.GetAddressById(id);
        }

        [HttpPost("/customers/{customerId}/addresses")]
        public Address CreateAddress(int customerId, Address address)
        {
            return _addressService.CreateAddress(address, customerId);
        }

        [HttpPut("/addresses/{id}")]
        public Address? UpdateAddress(int id, Address updatedAddress)
        {
            return _addressService.UpdateAddress(id, updatedAddress);
        }

        [HttpDelete("/addresses/{id}")]
        public bool DeleteAddress(int id)
        {
            return _addressService.DeleteAddress(id);
        }
    }
}