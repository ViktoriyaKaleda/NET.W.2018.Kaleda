namespace BLL.Interface.Entities
{
	public class PlatinumBankAccount : AbstractBankAccount
	{
		public decimal IncreaseCoefficient { get => 0.1M; } 

		public decimal DecreaseCoefficient { get => 0.01M; }

		public override BankAccountType AccountType { get => BankAccountType.PlatinumBankAccount; }

		public PlatinumBankAccount(string number) : base(number) {	}

		public PlatinumBankAccount(string number, AccountOwner owner, decimal balance, decimal bonusPoints)
			: base(number, owner, balance, bonusPoints) { }

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
