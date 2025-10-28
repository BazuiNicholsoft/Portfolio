using System.ComponentModel.DataAnnotations;

namespace API_Practice.src.models.databaseModels
{
    public class EmailModel
    {
        [Key]
        public int ID { get; set; }
        public required string EMAIL_ADDRESS { get; set; }
        public required int CUSTOMER_ID { get; set; }
        public bool IS_PRIMARY { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime MODIFIED_AT { get; set; }

        // Navigation property
        public CustomerModel? CUSTOMER { get; set; }
    }
}