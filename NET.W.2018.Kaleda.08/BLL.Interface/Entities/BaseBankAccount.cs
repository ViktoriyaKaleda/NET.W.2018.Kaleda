namespace BLL.Interface.Entities
{
	public class BaseBankAccount : AbstractBankAccount
	{
		public decimal IncreaseCoefficient { get => 0.04M; }

		public decimal DecreaseCoefficient { get => 0.02M; }

		public override BankAccountType AccountType { get => BankAccountType.BaseBankAccount; }

		public BaseBankAccount(string number) : base(number) { }

		public BaseBankAccount(string number, AccountOwner owner, decimal balance, decimal bonusPoints)
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
