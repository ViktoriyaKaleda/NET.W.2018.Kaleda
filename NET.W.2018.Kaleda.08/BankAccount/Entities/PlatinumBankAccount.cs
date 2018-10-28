namespace BankAccount.Entities
{
	public class PlatinumBankAccount : AbstractBankAccount
	{
		public decimal IncreaseCoefficient { get => 0.1M; } 

		public decimal DecreaseCoefficient { get => 0.01M; }

		public override BankAccountType AccountType { get => BankAccountType.Platinum; }

		public PlatinumBankAccount() : base() {	}

		public PlatinumBankAccount(AccountOwner owner, decimal balance, decimal bonusPoints)
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
