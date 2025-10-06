using API_Practice.src.enums;
using API_Practice.src.models.databaseModels;

namespace API_Practice.src.models.ControllerModels
{
    public class Account
    {
        public int ID { get; set; }
        public required AccountType AccountType { get; set; }
        public required int CustomerID { get; set; }
        public List<Transaction> Transactions { get; set; } = [];

        public static Account MapModelToAccount(AccountModel model)
        {
            return new Account
            {
                ID = model.ID,
                AccountType = model.ACCOUNT_TYPE,
                CustomerID = model.CUSTOMER_ID,
                Transactions = Transaction.MapModelToTransaction(model.TRANSACTIONS)
            };
        }

        public static AccountModel MapAccountToModel(Account account, Customer customer)
        {
            return new AccountModel
            {
                ID = account.ID,
                ACCOUNT_TYPE = account.AccountType,
                CUSTOMER_ID = account.CustomerID,
                CUSTOMER = Customer.MapCustomerToModel(customer),
                TRANSACTIONS = Transaction.MapTransactionToModel(account.Transactions, account),
                CREATED_AT = DateTime.Now,
                MODIFIED_AT = DateTime.Now
            };
        }

        public static List<Account> MapModelsToAccounts(List<AccountModel> models)
        {
            List<Account> accounts = [];
            foreach (var model in models)
            {
                accounts.Add(MapModelToAccount(model)); 
            }
            return accounts;
        }

        public static List<AccountModel> MapAccountsToModels(List<Account> accounts, Customer customer)
        {
            List<AccountModel> accountModels = [];
            foreach (var account in accounts)
            {
                accountModels.Add(MapAccountToModel(account, customer));
            }
            return accountModels;
        }
    }
}