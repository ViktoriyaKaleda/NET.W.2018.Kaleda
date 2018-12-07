namespace DAL.Interface.DTO
{
	public class BankAccount
	{
		public int BankAccountId { get; set; }

		public string AccountNumber { get; set; }

		public AccountOwner Owner { get; set; }

		public decimal Balance { get; set; }

		public decimal BonusPoints { get; set; }

		public BankAccountStatus Status { get; set; }

		public virtual BankAccountType AccountType { get; }

		public BankAccount() { }

		public BankAccount(string number)
			=> AccountNumber = number;
	}
}
