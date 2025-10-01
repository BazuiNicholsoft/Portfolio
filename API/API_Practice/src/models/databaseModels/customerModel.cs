using System.ComponentModel.DataAnnotations;

namespace API_Practice.src.models.databaseModels
{
    public class CustomerModel
    {
        [Key]
        public int ID { get; set; }
        public required string FIRST_NAME { get; set; }
        public string? MIDDLE_NAME { get; set; }
        public required string LAST_NAME { get; set; }
        public required DateTime BIRTH_DATE { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime MODIFIED_AT { get; set; }

        // Navigation properties
        public List<AddressModel> ADDRESSES { get; set; } = [];
        public List<EmailModel> EMAILS { get; set; } = [];
        public List<PhoneModel> PHONES { get; set; } = [];
    }
}