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
		}

	}
}