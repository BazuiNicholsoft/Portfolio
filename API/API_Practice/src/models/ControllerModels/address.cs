using API_Practice.src.models.databaseModels;

namespace API_Practice.src.models.ControllerModels
{
    public class Address
    {
        public int ID { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required int CustomerID { get; set; }
        public bool IsPrimary { get; set; }

        public static Address MapModelToAddress(AddressModel model)
        {
            return new Address
            {
                ID = model.ID,
                Street = model.STREET,
                City = model.CITY_NAME,
                State = model.STATE_NAME,
                ZipCode = model.ZIP_CODE,
                CustomerID = model.CUSTOMER_ID,
                IsPrimary = model.IS_PRIMARY
            };
        }

        public static List<Address> MapModelsToAddresses(List<AddressModel> models)
        {
            List<Address> addresses = [];
            foreach (var model in models)
            {
                addresses.Add(MapModelToAddress(model));
            }
            return addresses;
        }

        public static AddressModel MapAddressToModel(Address address, Customer customer)
        {
            return new AddressModel
            {
                ID = address.ID,
                STREET = address.Street,
                CITY_NAME = address.City,
                STATE_NAME = address.State,
                ZIP_CODE = address.ZipCode,
                CUSTOMER_ID = address.CustomerID,
                IS_PRIMARY = address.IsPrimary,
                CREATED_AT = DateTime.Now,
                MODIFIED_AT = DateTime.Now
            };
        }

        public static List<AddressModel> MapAddressesToModels(List<Address> addresses, Customer customer)
        {
            List<AddressModel> addressModels = [];
            foreach (var address in addresses)
            {
                addressModels.Add(MapAddressToModel(address, customer));
            }
            return addressModels;
        }
    }
}