using System.ComponentModel.DataAnnotations;

namespace API_Practice.src.models.databaseModels
{
    public class TransactionModel
    {
        [Key]
        public int ID { get; set; }

        public required int ACCOUNT_ID { get; set; }

        public required string TRANSACTION_TYPE { get; set; }

        public required decimal AMOUNT { get; set; }

        public required DateTime TRANSACTION_DATE { get; set; }

        public string? DESCRIPTION { get; set; }

        public DateTime CREATED_AT { get; set; }

        public DateTime MODIFIED_AT { get; set; }
        
    }       
    
}