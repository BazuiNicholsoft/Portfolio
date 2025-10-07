using API_Practice.src.models.ControllerModels;
using API_Practice.src.services;
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.src.controllers
{
    public class AccountController
    {
        public AccountService _accountService;

        public AccountController()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("database")
                .Options;
            var databaseContext = new DatabaseContext(options);
            _accountService = new AccountService(databaseContext);
        }

        [HttpGet("/accounts")]
        public List<Account> GetAllAccounts()
        {
            return _accountService.GetAllAccounts();
        }

        [HttpGet("/accounts/{id}")]
        public Account? GetAccountById(int id)
        {
            return _accountService.GetAccountById(id);
        }

        [HttpPost("/customers/{customerId}/accounts")]
        public Account CreateAccount(int customerId, Account account)
        {
            return _accountService.CreateAccount(account, customerId);
        }

        [HttpPut("/accounts/{id}")]
        public Account? UpdateAccount(int id, Account updatedAccount)
        {
            return _accountService.UpdateAccount(id, updatedAccount);
        }

        [HttpDelete("/accounts/{id}")]
        public bool DeleteAccount(int id)
        {
            return _accountService.DeleteAccount(id);
        }
    }
}