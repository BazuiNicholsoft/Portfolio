using API_Practice.src.database;
using API_Practice.src.models.ControllerModels;

namespace API_Practice.src.services
{
    public class TransactionService(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;

        public List<Transaction> GetAllTransactions()
        {
            var transactionModels = _dbContext.Transactions.ToList();
            return Transaction.MapModelsToTransactions(transactionModels);
        }

        public List<Transaction> GetTransactionsByAccountId(int accountId)
        {
            var transactionModels = _dbContext.Transactions.Where(t => t.ACCOUNT_ID == accountId).ToList();
            return Transaction.MapModelsToTransactions(transactionModels);
        }

        public Transaction? GetTransactionById(int id)
        {
            var transactionModel = _dbContext.Transactions.FirstOrDefault(t => t.ID == id);
            if (transactionModel == null)
            {
                return null;
            }
            return Transaction.MapModelToTransaction(transactionModel);
        }

        public Transaction CreateTransaction(Transaction transaction, int accountId)
        {
            var accountModel = _dbContext.Accounts.FirstOrDefault(a => a.ID == accountId) ?? throw new Exception("Account not found");
            var account = Account.MapModelToAccount(accountModel);
            var transactionModel = Transaction.MapTransactionToModel(transaction, account);
            _dbContext.Transactions.Add(transactionModel);
            _dbContext.SaveChanges();
            return Transaction.MapModelToTransaction(transactionModel);
        }

        public Transaction? UpdateTransaction(int id, Transaction updatedTransaction)
        {
            var transactionModel = _dbContext.Transactions.FirstOrDefault(t => t.ID == id);
            if (transactionModel == null)
            {
                return null;
            }

            transactionModel.TRANSACTION_TYPE = updatedTransaction.TransactionType;
            transactionModel.AMOUNT = updatedTransaction.Amount;
            transactionModel.DESCRIPTION = updatedTransaction.Description;
            transactionModel.MODIFIED_AT = DateTime.Now;

            _dbContext.SaveChanges();
            return Transaction.MapModelToTransaction(transactionModel);
        }

        public void DeleteTransaction(int id)
        {
            var transactionModel = _dbContext.Transactions.FirstOrDefault(t => t.ID == id) ?? throw new Exception("Transaction not found");
            _dbContext.Transactions.Remove(transactionModel);
            _dbContext.SaveChanges();
        }
    }
}