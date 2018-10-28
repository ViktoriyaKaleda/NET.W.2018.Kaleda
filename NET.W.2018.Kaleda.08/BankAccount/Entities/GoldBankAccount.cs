namespace BankAccount.Entities
{
	public class GoldBankAccount : AbstractBankAccount
	{
		public decimal IncreaseCoefficient { get => 0.05M; }

		public decimal DecreaseCoefficient { get => 0.015M; }

		public override BankAccountType AccountType { get => BankAccountType.Gold; }

		public GoldBankAccount() : base() { }

		public GoldBankAccount(AccountOwner owner, decimal balance, decimal bonusPoints)
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
