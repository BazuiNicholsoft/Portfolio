using API_Practice.src.models.ControllerModels;
using API_Practice.src.services;
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice.src.controllers
{
    public class TransactionController
    {
        public TransactionService _transactionService;

        public TransactionController()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("database")
                .Options;
            var databaseContext = new DatabaseContext(options);
            _transactionService = new TransactionService(databaseContext);
        }

        [HttpGet("/transactions")]
        public List<Transaction> GetAllTransactions()
        {
            return _transactionService.GetAllTransactions();
        }

        [HttpGet("/transactions/{id}")]
        public Transaction? GetTransactionById(int id)
        {
            return _transactionService.GetTransactionById(id);
        }

        [HttpPost("/accounts/{accountId}/transactions")]
        public Transaction CreateTransaction(int accountId, Transaction transaction)
        {
            return _transactionService.CreateTransaction(transaction, accountId);
        }

        [HttpPut("/transactions/{id}")]
        public Transaction? UpdateTransaction(int id, Transaction updatedTransaction)
        {
            return _transactionService.UpdateTransaction(id, updatedTransaction);
        }

        [HttpDelete("/transactions/{id}")]
        public bool DeleteTransaction(int id)
        {
            return _transactionService.DeleteTransaction(id);
        }
    }
}