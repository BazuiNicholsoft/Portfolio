using API_Practice.src.models.databaseModels;

namespace API_Practice.src.models.ControllerModels
{
    public class Email
    {
        public int ID { get; set; }
        public required string EmailAddress { get; set; }
        public required int CustomerID { get; set; }
        public bool IsPrimary { get; set; }

        public static Email MapModelToEmail(EmailModel model)
        {
            return new Email
            {
                ID = model.ID,
                EmailAddress = model.EMAIL_ADDRESS,
                CustomerID = model.CUSTOMER_ID,
                IsPrimary = model.IS_PRIMARY
            };
        }
        public static List<Email> MapModelsToEmails(List<EmailModel> models)
        {
            List<Email> emails = [];
            foreach (var model in models)
            {
                emails.Add(MapModelToEmail(model));
            }
            return emails;
        }

        public static EmailModel MapEmailToModel(Email email, CustomerModel customer)
        {
            return new EmailModel
            {
                ID = email.ID,
                EMAIL_ADDRESS = email.EmailAddress,
                CUSTOMER_ID = email.CustomerID,
                CUSTOMER = customer,
                IS_PRIMARY = email.IsPrimary,
                CREATED_AT = DateTime.Now,
                MODIFIED_AT = DateTime.Now
            };
        }

        public static List<EmailModel> MapEmailsToModels(List<Email> emails, CustomerModel customer)
        {
            List<EmailModel> emailModels = [];
            foreach (var email in emails)
            {
                emailModels.Add(MapEmailToModel(email, customer));
            }
            return emailModels;
        }
    }
}