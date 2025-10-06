using System.ComponentModel.DataAnnotations;
using API_Practice.src.enums;

namespace API_Practice.src.models.databaseModels
{
    public class AccountModel
    {
        [Key]
        public int ID { get; set; }
        public required AccountType ACCOUNT_TYPE { get; set; }
        public required int CUSTOMER_ID { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime MODIFIED_AT { get; set; }

        // Navigation property
        public CustomerModel? CUSTOMER { get; set; }
        public List<TransactionModel> TRANSACTIONS { get; set; } = [];
        
    }
}