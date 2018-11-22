namespace DAL.Interface.DTO
{
	public class GoldBankAccount : BankAccount
	{
		public GoldBankAccount() { }
		public GoldBankAccount(string number) : base(number) { }

		public override BankAccountType AccountType { get => BankAccountType.GoldBankAccount; }
	}
}
