using System.ComponentModel.DataAnnotations;

namespace API_Practice.src.models.databaseModels
{
    public class AccountModel
    {
        [Key]
        public int ID { get; set; }
        public required string ACCOUNT_TYPE { get; set; }
        public required decimal BALANCE { get; set; }
        public required int CUSTOMER_ID { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime MODIFIED_AT { get; set; }

        // Navigation property
        public List<TransactionModel> TRANSACTIONS { get; set; } = [];
        
    }
}