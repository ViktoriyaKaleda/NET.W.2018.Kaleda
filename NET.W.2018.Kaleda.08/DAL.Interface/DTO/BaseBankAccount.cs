namespace DAL.Interface.DTO
{
	public class BaseBankAccount : BankAccount
	{
		public BaseBankAccount() { }
		public BaseBankAccount(string number) : base(number) { }

		public override BankAccountType AccountType { get => BankAccountType.BaseBankAccount; }
	}
}
