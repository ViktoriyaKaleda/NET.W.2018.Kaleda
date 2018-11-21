namespace DAL.Interface.DTO
{
	public class BankAccount
	{
		public string AccountNumber { get; set; }

		public AccountOwner Owner { get; set; }

		public decimal Balance { get; set; }

		public decimal BonusPoints { get; set; }

		public BankAccountStatus Status { get; set; }

		public BankAccountType AccountType { get; }
	}
}
