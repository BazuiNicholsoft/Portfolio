using API_Practice.src.database;
using API_Practice.src.models.ControllerModels;

namespace API_Practice.src.services
{
    public class AccountService(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;

        public List<Account> GetAllAccounts()
        {
            var accountModels = _dbContext.Accounts.ToList();
            return Account.MapModelsToAccounts(accountModels);
        }

        public List<Account> GetAccountsByCustomerId(int customerId)
        {
            var accountModels = _dbContext.Accounts.Where(a => a.CUSTOMER_ID == customerId).ToList();
            return Account.MapModelsToAccounts(accountModels);
        }

        public Account? GetAccountById(int id)
        {
            var accountModel = _dbContext.Accounts.FirstOrDefault(a => a.ID == id);
            if (accountModel == null)
            {
                return null;
            }
            return Account.MapModelToAccount(accountModel);
        }

        public Account CreateAccount(Account account, int customerId)
        {
            var customerModel = _dbContext.Customers.FirstOrDefault(c => c.ID == customerId) ?? throw new Exception("Customer not found");
            var customer = Customer.MapModelToCustomer(customerModel);
            var accountModel = Account.MapAccountToModel(account, customer);
            _dbContext.Accounts.Add(accountModel);
            _dbContext.SaveChanges();
            return Account.MapModelToAccount(accountModel);
        }

        public Account? UpdateAccount(int id, Account updatedAccount)
        {
            var accountModel = _dbContext.Accounts.FirstOrDefault(a => a.ID == id);
            if (accountModel == null)
            {
                return null;
            }

            accountModel.ACCOUNT_TYPE = updatedAccount.AccountType;
            accountModel.MODIFIED_AT = DateTime.Now;

            _dbContext.SaveChanges();
            return Account.MapModelToAccount(accountModel);
        }

        public bool DeleteAccount(int id)
        {
            var accountModel = _dbContext.Accounts.FirstOrDefault(a => a.ID == id) ?? throw new Exception("Account not found");
            _dbContext.Accounts.Remove(accountModel);
            _dbContext.SaveChanges();
            return true;
        }   
    }
}