using DAL.Interface.DTO;
using System.Data.Entity;

namespace DAL.EF
{
	public class BankAccountContext : DbContext
    {
		public BankAccountContext() : base() { }

		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<AccountOwner> Owners { get; set; }
	}
}
