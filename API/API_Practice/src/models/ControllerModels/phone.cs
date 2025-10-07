using API_Practice.src.enums;
using API_Practice.src.models.databaseModels;

namespace API_Practice.src.models.ControllerModels
{
    public class Phone
    {
        public int ID { get; set; }
        public required string PhoneNumber { get; set; }
        public required PhoneType PhoneType { get; set; }
        public bool IsPrimary { get; set; }
        public required int CustomerID { get; set; }

        public static Phone MapModelToPhone(PhoneModel model)
        {
            return new Phone
            {
                ID = model.ID,
                PhoneNumber = model.PHONE_NUMBER,
                PhoneType = model.PHONE_TYPE,
                IsPrimary = model.IS_PRIMARY,
                CustomerID = model.CUSTOMER_ID
            };
        }

        public static List<Phone> MapModelsToPhones(List<PhoneModel> models)
        {
            List<Phone> phones = [];
            foreach (var model in models)
            {
                phones.Add(MapModelToPhone(model));
            }
            return phones;
        }

        public static PhoneModel MapPhoneToModel(Phone phone, Customer customer)
        {
            return new PhoneModel
            {
                ID = phone.ID,
                PHONE_NUMBER = phone.PhoneNumber,
                PHONE_TYPE = phone.PhoneType,
                IS_PRIMARY = phone.IsPrimary,
                CUSTOMER_ID = phone.CustomerID,
                CUSTOMER = Customer.MapCustomerToModel(customer),
                CREATED_AT = DateTime.Now,
                MODIFIED_AT = DateTime.Now
            };
        }

        public static List<PhoneModel> MapPhonesToModels(List<Phone> phones, Customer customer)
        {
            List<PhoneModel> phoneModels = [];
            foreach (var phone in phones)
            {
                phoneModels.Add(MapPhoneToModel(phone, customer));
            }
            return phoneModels;
        }

    }
}