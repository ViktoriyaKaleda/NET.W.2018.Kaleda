namespace BankAccount.Entities
{
	public class BaseBankAccount : AbstractBankAccount
	{
		public decimal IncreaseCoefficient { get => 0.04M; }

		public decimal DecreaseCoefficient { get => 0.02M; }

		public override BankAccountType AccountType { get => BankAccountType.Base; }

		public BaseBankAccount() : base() { }

		public BaseBankAccount(AccountOwner owner, decimal balance, decimal bonusPoints)
			: base(owner, balance, bonusPoints) { }

		protected override void IncreaseBonusPoints(decimal sum)
		{
			BonusPoints += sum * IncreaseCoefficient;
		}

		protected override void DecreaseBonusPoints(decimal sum)
		{
			BonusPoints -= sum * DecreaseCoefficient;
		}
	}
}
