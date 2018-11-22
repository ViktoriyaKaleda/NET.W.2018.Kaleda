namespace DAL.Interface.DTO
{
	public class PlatinumBankAccount : BankAccount
	{
		public PlatinumBankAccount() { }
		public PlatinumBankAccount(string number) : base(number) { }

		public override BankAccountType AccountType { get => BankAccountType.PlatinumBankAccount; }
	}
}
