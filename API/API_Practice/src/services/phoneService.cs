using API_Practice.src.database;
using API_Practice.src.models.ControllerModels;

namespace API_Practice.src.services
{
    public class PhoneService(DatabaseContext context)
    {
        private readonly DatabaseContext _context = context;

        public List<Phone> GetAllPhones()
        {
            var phoneModels = _context.Phones.ToList();
            return Phone.MapModelsToPhones(phoneModels);
        }

        public List<Phone> GetPhonesByCustomerId(int customerId)
        {
            var phoneModels = _context.Phones.Where(p => p.CUSTOMER_ID == customerId).ToList();
            return Phone.MapModelsToPhones(phoneModels);
        }

        public Phone? GetPhoneById(int id)
        {
            var phoneModel = _context.Phones.FirstOrDefault(p => p.ID == id);
            if (phoneModel == null)
            {
                return null;
            }
            return Phone.MapModelToPhone(phoneModel);
        }

        public Phone CreatePhone(Phone phone, int customerId)
        {
            var customerModel = _context.Customers.FirstOrDefault(c => c.ID == customerId) ?? throw new Exception("Customer not found");
            var customer = Customer.MapModelToCustomer(customerModel);
            var phoneModel = Phone.MapPhoneToModel(phone, customer);
            _context.Phones.Add(phoneModel);
            _context.SaveChanges();
            return Phone.MapModelToPhone(phoneModel);
        }

        public Phone? UpdatePhone(int id, Phone updatedPhone)
        {
            var phoneModel = _context.Phones.FirstOrDefault(p => p.ID == id);
            if (phoneModel == null)
            {
                return null;
            }

            phoneModel.PHONE_NUMBER = updatedPhone.PhoneNumber;
            phoneModel.MODIFIED_AT = DateTime.Now;

            _context.SaveChanges();
            return Phone.MapModelToPhone(phoneModel);
        }

        public bool DeletePhone(int id)
        {
            var phoneModel = _context.Phones.FirstOrDefault(p => p.ID == id);
            if (phoneModel == null)
            {
                return false;
            }
            _context.Phones.Remove(phoneModel);
            _context.SaveChanges();
            return true;
        }
    }
}