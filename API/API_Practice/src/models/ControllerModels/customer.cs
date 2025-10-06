using API_Practice.src.models.databaseModels;

namespace API_Practice.src.models.ControllerModels
{
    public class Customer
    {
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateTime BirthDate { get; set; }

        public List<Address> Addresses { get; set; } = [];
        public List<Email> Emails { get; set; } = [];
        public List<Phone> Phones { get; set; } = [];
        public List<Account> Accounts { get; set; } = [];

        public static Customer MapModelToCustomer(CustomerModel model)
        {
            return new Customer
            {
                ID = model.ID,
                FirstName = model.FIRST_NAME,
                MiddleName = model.MIDDLE_NAME,
                LastName = model.LAST_NAME,
                BirthDate = model.BIRTH_DATE,
                Addresses = Address.MapModelsToAddresses(model.ADDRESSES),
                Emails = Email.MapModelsToEmails(model.EMAILS),
                Phones = Phone.MapModelsToPhones(model.PHONES),
                Accounts = Account.MapModelsToAccounts(model.ACCOUNTS)
            };
        }

        public static CustomerModel MapCustomerToModel(Customer customer)
        {
            return new CustomerModel
            {
                ID = customer.ID,
                FIRST_NAME = customer.FirstName,
                MIDDLE_NAME = customer.MiddleName,
                LAST_NAME = customer.LastName,
                BIRTH_DATE = customer.BirthDate,
                ADDRESSES = Address.MapAddressesToModels(customer.Addresses, null!),
                EMAILS = Email.MapEmailsToModels(customer.Emails, null!),
                PHONES = Phone.MapPhonesToModels(customer.Phones, null!),
                ACCOUNTS = Account.MapAccountsToModels(customer.Accounts, null!),
                CREATED_AT = DateTime.Now,
                MODIFIED_AT = DateTime.Now
            };
        }
        public static List<Customer> MapModelsToCustomers(List<CustomerModel> models)
        {
            List<Customer> customers = [];
            foreach (var model in models)
            {
                customers.Add(MapModelToCustomer(model));
            }
            return customers;
        }
        
        public static List<CustomerModel> MapCustomersToModels(List<Customer> customers)
        {
            List<CustomerModel> customerModels = [];
            foreach (var customer in customers)
            {
                customerModels.Add(MapCustomerToModel(customer));
            }
            return customerModels;
        }
    }
}