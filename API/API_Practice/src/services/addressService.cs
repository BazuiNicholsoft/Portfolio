using API_Practice.src.database;
using API_Practice.src.models.ControllerModels;

namespace API_Practice.src.services
{
    public class AddressService(DatabaseContext context)
    {
        private readonly DatabaseContext _context = context;

        public List<Address> GetAllAddresses()
        {
            var addressModels = _context.Addresses.ToList();
            return Address.MapModelsToAddresses(addressModels);
        }

        public List<Address> GetAddressesByCustomerId(int customerId)
        {
            var addressModels = _context.Addresses.Where(a => a.CUSTOMER_ID == customerId).ToList();
            return Address.MapModelsToAddresses(addressModels);
        }

        public Address? GetAddressById(int id)
        {
            var addressModel = _context.Addresses.FirstOrDefault(a => a.ID == id);
            if (addressModel == null)
            {
                return null;
            }
            return Address.MapModelToAddress(addressModel);
        }

        public Address CreateAddress(Address address, int customerId)
        {
            var customerModel = _context.Customers.FirstOrDefault(c => c.ID == customerId) ?? throw new Exception("Customer not found");
            var customer = Customer.MapModelToCustomer(customerModel);
            var addressModel = Address.MapAddressToModel(address, customer);
            _context.Addresses.Add(addressModel);
            _context.SaveChanges();
            return Address.MapModelToAddress(addressModel);
        }

        public Address? UpdateAddress(int id, Address updatedAddress)
        {
            var addressModel = _context.Addresses.FirstOrDefault(a => a.ID == id);
            if (addressModel == null)
            {
                return null;
            }

            addressModel.STREET = updatedAddress.Street;
            addressModel.CITY_NAME = updatedAddress.City;
            addressModel.STATE_NAME = updatedAddress.State;
            addressModel.ZIP_CODE = updatedAddress.ZipCode;
            addressModel.MODIFIED_AT = DateTime.Now;

            _context.SaveChanges();
            return Address.MapModelToAddress(addressModel);
        }

        public bool DeleteAddress(int id)
        {
            var addressModel = _context.Addresses.FirstOrDefault(a => a.ID == id);
            if (addressModel == null)
            {
                return false;
            }
            _context.Addresses.Remove(addressModel);
            _context.SaveChanges();
            return true;
        }
    }
}