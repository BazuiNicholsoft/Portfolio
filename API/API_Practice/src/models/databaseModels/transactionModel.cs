using System.ComponentModel.DataAnnotations;
using API_Practice.src.enums;

namespace API_Practice.src.models.databaseModels
{
    public class TransactionModel
    {
        [Key]
        public int ID { get; set; }

        public required int ACCOUNT_ID { get; set; }

        public required TransactionType TRANSACTION_TYPE { get; set; }

        public required decimal AMOUNT { get; set; }

        public required DateTime TRANSACTION_DATE { get; set; }

        public string? DESCRIPTION { get; set; }

        public DateTime CREATED_AT { get; set; }

        public DateTime MODIFIED_AT { get; set; }

        public AccountModel? ACCOUNT { get; set; }

        public TransactionModel()
        {
            AMOUNT = 0.0M;
            TRANSACTION_DATE = DateTime.Now;
            CREATED_AT = DateTime.Now;
            MODIFIED_AT = DateTime.Now;
        }
        
    }
}