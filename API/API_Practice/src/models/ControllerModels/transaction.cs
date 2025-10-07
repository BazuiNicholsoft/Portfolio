using API_Practice.src.enums;
using API_Practice.src.models.databaseModels;

namespace API_Practice.src.models.ControllerModels
{
    public class Transaction
    {
        public int ID { get; set; }
        public required int AccountID { get; set; }
        public required TransactionType TransactionType { get; set; }
        public required decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }

        public static List<Transaction> MapModelsToTransactions(List<TransactionModel> model)
        {
            List<Transaction> transactions = [];
            foreach (var transactionModel in model)
            {
                transactions.Add(MapModelToTransaction(transactionModel));
            }
            return transactions;
        }

        public static Transaction MapModelToTransaction(TransactionModel model)
        {
            return new Transaction
            {
                ID = model.ID,
                AccountID = model.ACCOUNT_ID,
                TransactionType = model.TRANSACTION_TYPE,
                Amount = model.AMOUNT,
                TransactionDate = model.TRANSACTION_DATE,
                Description = model.DESCRIPTION
            };
        }

        public static TransactionModel MapTransactionToModel(Transaction transaction, Account account)
        {
            return new TransactionModel
            {
                ID = transaction.ID,
                ACCOUNT_ID = transaction.AccountID,
                TRANSACTION_TYPE = transaction.TransactionType,
                AMOUNT = transaction.Amount,
                TRANSACTION_DATE = transaction.TransactionDate,
                DESCRIPTION = transaction.Description,
                CREATED_AT = DateTime.Now,
                MODIFIED_AT = DateTime.Now
            };
        }
        
        public static List<TransactionModel> MapTransactionsToModels(List<Transaction> transactions, Account account)
        {
            List<TransactionModel> transactionModels = [];
            foreach (var transaction in transactions)
            {
                transactionModels.Add(MapTransactionToModel(transaction, account));
            }
            return transactionModels;
        }
    }


}