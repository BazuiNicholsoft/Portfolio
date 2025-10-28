using API_Practice.src.models.databaseModels;
using Microsoft.EntityFrameworkCore;

namespace API_Practice.src.database
{

	public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
	{
        public DbSet<CustomerModel> Customers { get; set; }
		public DbSet<EmailModel> Emails { get; set; }
		public DbSet<AddressModel> Addresses { get; set; }
		public DbSet<PhoneModel> Phones { get; set; }
		public DbSet<AccountModel> Accounts { get; set; }
		public DbSet<TransactionModel> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomerModel>().HasData(
				new CustomerModel
				{
					ID = 1,
					FIRST_NAME = "John",
					MIDDLE_NAME = "A",
					LAST_NAME = "Doe",
					BIRTH_DATE = new DateTime(1990, 1, 1),
					CREATED_AT = DateTime.UtcNow,
					MODIFIED_AT = DateTime.UtcNow
				}
			);

			modelBuilder.Entity<EmailModel>().HasData(
				new EmailModel
				{
					ID = 1,
					CUSTOMER_ID = 1,
					EMAIL_ADDRESS = "john.doe@example.com",
					CREATED_AT = DateTime.UtcNow,
					MODIFIED_AT = DateTime.UtcNow
				}
			);

			modelBuilder.Entity<PhoneModel>().HasData(
				new PhoneModel
				{
					ID = 1,
					CUSTOMER_ID = 1,
					PHONE_NUMBER = "123-456-7890",
					PHONE_TYPE = enums.PhoneType.Mobile,
					CREATED_AT = DateTime.UtcNow,
					MODIFIED_AT = DateTime.UtcNow
				}
			);

			modelBuilder.Entity<AddressModel>().HasData(
				new AddressModel
				{
					ID = 1,
					CUSTOMER_ID = 1,
					STREET = "123 Main St",
					CITY_NAME = "Anytown",
					STATE_NAME = "CA",
					ZIP_CODE = "12345",
					CREATED_AT = DateTime.UtcNow,
					MODIFIED_AT = DateTime.UtcNow
				}
			);

			modelBuilder.Entity<AccountModel>().HasData(
				new AccountModel
				{
					ID = 1,
					CUSTOMER_ID = 1,
					ACCOUNT_TYPE = enums.AccountType.Checking,
					CREATED_AT = DateTime.UtcNow,
					MODIFIED_AT = DateTime.UtcNow
				}
			);

			modelBuilder.Entity<TransactionModel>().HasData(
				new TransactionModel
				{
					ID = 1,
					ACCOUNT_ID = 1,
					AMOUNT = 100.00m,
					TRANSACTION_DATE = DateTime.UtcNow,
					TRANSACTION_TYPE = enums.TransactionType.Deposit,
					DESCRIPTION = "Initial Deposit",
					CREATED_AT = DateTime.UtcNow,
					MODIFIED_AT = DateTime.UtcNow
				}
			);

			modelBuilder.Entity<CustomerModel>()
				.HasMany(c => c.EMAILS)
				.WithOne(e => e.CUSTOMER)
				.HasForeignKey(e => e.CUSTOMER_ID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<CustomerModel>()
				.HasMany(c => c.ADDRESSES)
				.WithOne(a => a.CUSTOMER)
				.HasForeignKey(a => a.CUSTOMER_ID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<CustomerModel>()
				.HasMany(c => c.PHONES)
				.WithOne(p => p.CUSTOMER)
				.HasForeignKey(p => p.CUSTOMER_ID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<CustomerModel>()
				.HasMany(c => c.ACCOUNTS)
				.WithOne(a => a.CUSTOMER)
				.HasForeignKey(a => a.CUSTOMER_ID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<AccountModel>()
				.HasMany(a => a.TRANSACTIONS)
				.WithOne(t => t.ACCOUNT)
				.HasForeignKey(t => t.ACCOUNT_ID)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
		}

	}
}