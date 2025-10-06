using System.ComponentModel.DataAnnotations;
using API_Practice.src.enums;

namespace API_Practice.src.models.databaseModels
{
    public class PhoneModel
    {
        [Key]
        public int ID { get; set; }
        public required int CUSTOMER_ID { get; set; }
        public required string PHONE_NUMBER { get; set; }
        public required PhoneType PHONE_TYPE { get; set; }
        public bool IS_PRIMARY { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime MODIFIED_AT { get; set; }

        // Navigation property
        public required CustomerModel CUSTOMER { get; set; }
    }   
}