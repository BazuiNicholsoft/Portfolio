using System.ComponentModel.DataAnnotations;

namespace API_Practice.src.models.databaseModels
{
    public class AddressModel
    {
        [Key]
        public int ID { get; set; }
        public required string STREET { get; set; }
        public required string CITY_NAME { get; set; }
        public required string STATE_NAME { get; set; }
        public required string ZIP_CODE { get; set; }
        public required int CUSTOMER_ID { get; set; }
        public bool IS_PRIMARY { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime MODIFIED_AT { get; set; }

        // Navigation property
        public CustomerModel? CUSTOMER { get; set; }
    }
}