using API_Practice.src.database;
using API_Practice.src.models.ControllerModels;

namespace API_Practice.src.services
{
    public class EmailService(DatabaseContext context)
    {
        private readonly DatabaseContext _context = context;

        public List<Email> GetAllEmails()
        {
            var emailModels = _context.Emails.ToList();
            return Email.MapModelsToEmails(emailModels);
        }

        public List<Email> GetEmailsByCustomerId(int customerId)
        {
            var emailModels = _context.Emails.Where(e => e.CUSTOMER_ID == customerId).ToList();
            return Email.MapModelsToEmails(emailModels);
        }

        public Email? GetEmailById(int id)
        {
            var emailModel = _context.Emails.FirstOrDefault(e => e.ID == id);
            if (emailModel == null)
            {
                return null;
            }
            return Email.MapModelToEmail(emailModel);
        }

        public Email CreateEmail(Email email, int customerId)
        {
            var customerModel = _context.Customers.FirstOrDefault(c => c.ID == customerId) ?? throw new Exception("Customer not found");
            var customer = Customer.MapModelToCustomer(customerModel);
            var emailModel = Email.MapEmailToModel(email, customer);
            _context.Emails.Add(emailModel);
            _context.SaveChanges();
            return Email.MapModelToEmail(emailModel);
        }

        public Email? UpdateEmail(int id, Email updatedEmail)
        {
            var emailModel = _context.Emails.FirstOrDefault(e => e.ID == id);
            if (emailModel == null)
            {
                return null;
            }

            emailModel.EMAIL_ADDRESS = updatedEmail.EmailAddress;
            emailModel.MODIFIED_AT = DateTime.Now;

            _context.SaveChanges();
            return Email.MapModelToEmail(emailModel);
        }

        public bool DeleteEmail(int id)
        {
            var emailModel = _context.Emails.FirstOrDefault(e => e.ID == id) ?? throw new Exception("Email not found");
            _context.Emails.Remove(emailModel);
            _context.SaveChanges();
            return true;
        }
    }

}