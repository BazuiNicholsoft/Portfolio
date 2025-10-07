using API_Practice.src.database;
using API_Practice.src.models.ControllerModels;

namespace API_Practice.src.services
{
    public class CustomerService(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;

        public List<Customer> GetAllCustomers()
        {
            var customerModels = _dbContext.Customers.ToList();
            return Customer.MapModelsToCustomers(customerModels);
        }

        public Customer? GetCustomerById(int id)
        {
            var customerModel = _dbContext.Customers.FirstOrDefault(c => c.ID == id);
            if (customerModel == null)
            {
                return null;
            }
            return Customer.MapModelToCustomer(customerModel);
        }

        public Customer CreateCustomer(Customer customer)
        {
            var customerModel = Customer.MapCustomerToModel(customer);
            _dbContext.Customers.Add(customerModel);
            _dbContext.SaveChanges();
            return Customer.MapModelToCustomer(customerModel);
        }

        public Customer? UpdateCustomer(int id, Customer updatedCustomer)
        {
            var customerModel = _dbContext.Customers.FirstOrDefault(c => c.ID == id);
            if (customerModel == null)
            {
                return null;
            }

            customerModel.FIRST_NAME = updatedCustomer.FirstName;
            customerModel.MIDDLE_NAME = updatedCustomer.MiddleName;
            customerModel.LAST_NAME = updatedCustomer.LastName;
            customerModel.BIRTH_DATE = updatedCustomer.BirthDate;
            customerModel.MODIFIED_AT = DateTime.Now;

            _dbContext.SaveChanges();
            return Customer.MapModelToCustomer(customerModel);
        }

        public bool DeleteCustomer(int id)
        {
            var customerModel = _dbContext.Customers.FirstOrDefault(c => c.ID == id);
            if (customerModel == null)
            {
                return false;
            }
            _dbContext.Customers.Remove(customerModel);
            _dbContext.SaveChanges();
            return true;
        }
    }
}