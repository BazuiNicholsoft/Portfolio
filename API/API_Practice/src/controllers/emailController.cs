using API_Practice.src.models.ControllerModels;
using API_Practice.src.services;
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.src.controllers
{
    public class EmailController
    {
        public EmailService _emailService;

        public EmailController()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("database")
                .Options;
            var databaseContext = new DatabaseContext(options);
            _emailService = new EmailService(databaseContext);
        }

        [HttpGet("/emails")]
        public List<Email> GetAllEmails()
        {
            return _emailService.GetAllEmails();
        }

        [HttpGet("/emails/{id}")]
        public Email? GetEmailById(int id)
        {
            return _emailService.GetEmailById(id);
        }

        [HttpPost("/customers/{customerId}/emails")]
        public Email CreateEmail(int customerId, Email email)
        {
            return _emailService.CreateEmail(email, customerId);
        }

        [HttpPut("/emails/{id}")]
        public Email? UpdateEmail(int id, Email updatedEmail)
        {
            return _emailService.UpdateEmail(id, updatedEmail);
        }

        [HttpDelete("/emails/{id}")]
        public bool DeleteEmail(int id)
        {
            return _emailService.DeleteEmail(id);
        }
    }
}