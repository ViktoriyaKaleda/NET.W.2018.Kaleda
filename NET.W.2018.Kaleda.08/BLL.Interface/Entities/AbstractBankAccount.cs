using System;

namespace BLL.Interface.Entities
{
	public abstract class AbstractBankAccount : IEquatable<AbstractBankAccount>
	{
		public string AccountNumber { get; set; }

		public AccountOwner Owner { get; set; }

		public decimal Balance { get; set; }

		public decimal BonusPoints { get; set; }

		public BankAccountStatus Status { get; set; }

		public AbstractBankAccount(string number)
		{
			AccountNumber = number;
			Status = BankAccountStatus.Opened;
		}

		public AbstractBankAccount(string number, AccountOwner owner, decimal balance, decimal bonusPoints)
		{
			AccountNumber = number;
			Owner = owner;
			Balance = balance;
			BonusPoints = bonusPoints;
			Status = BankAccountStatus.Opened;
		}

		public override bool Equals(object other)
		{
			if (other == null)
				return false;

			if (other is AbstractBankAccount)
				return Equals((AbstractBankAccount)other);

			return false;
		}

		public bool Equals(AbstractBankAccount other)
		{
			if ((object)other == null)
				return false;

			return this.AccountNumber.Equals(other.AccountNumber);
		}

		public override int GetHashCode()
		{
			return AccountNumber.GetHashCode();
		}

		public override string ToString()
		{
			return $"Number: {AccountNumber};\nAccount type: {AccountType};\nOwner: {Owner.FirstName} {Owner.LastName};" +
				$"\nBalance: {Balance};\nBonus points: {BonusPoints};\nStatus: {Status};";
		}

		public virtual void Deposit(decimal sum)
		{
			Balance += sum;
			IncreaseBonusPoints(sum);
		}

		public virtual void Withdraw(decimal sum)
		{
			Balance -= sum;
			DecreaseBonusPoints(sum);
		}

		public virtual void Close()
		{
			Status = BankAccountStatus.Closed;
			Balance = 0;
			BonusPoints = 0;
		}

		public abstract BankAccountType AccountType { get; }

		protected abstract void IncreaseBonusPoints(decimal sum);

		protected abstract void DecreaseBonusPoints(decimal sum);
	}
}
