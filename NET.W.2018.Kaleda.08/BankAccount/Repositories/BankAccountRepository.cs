using System;
using System.Collections.Generic;
using System.IO;
using BankAccount.Entities;
using BankAccount.Exceptions;

namespace BankAccount.Repositories
{
	public class BankAccountRepository : IBankAccountRepository
	{
		public List<AbstractBankAccount> Accounts { get; }

		private string RepositoryFileName { get; }

		public BankAccountRepository()
		{
			Accounts = new List<AbstractBankAccount>();
			RepositoryFileName = Settings.Default.BinaryRepositoryFileName;

			if (!File.Exists(RepositoryFileName))
				return;

			Stream stream = File.OpenRead(RepositoryFileName);
			using (var reader = new BinaryReader(stream))
			{
				int count = reader.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					string accountNumber = reader.ReadString();
					string ownerFirstName = reader.ReadString();
					string ownerLastName = reader.ReadString();
					decimal balance = reader.ReadDecimal();
					decimal bonusPoints = reader.ReadDecimal();
					BankAccountStatus status = (BankAccountStatus)reader.ReadInt32();

					BankAccountType type = (BankAccountType)reader.ReadInt32();

					var owner = new AccountOwner() { FirstName = ownerFirstName, LastName = ownerLastName };

					switch(type)
					{
						case BankAccountType.Base:
							Accounts.Add(InitializeFields(new BaseBankAccount(), accountNumber, owner, balance, bonusPoints));
							break;

						case BankAccountType.Gold:
							Accounts.Add(InitializeFields(new GoldBankAccount(), accountNumber, owner, balance, bonusPoints));
							break;

						case BankAccountType.Platinum:
							Accounts.Add(InitializeFields(new PlatinumBankAccount(), accountNumber, owner, balance, bonusPoints));
							break;

						default:
							throw new UnknownBankAccountTypeException("Unknown account type passed.", nameof(type));
					}					
				}
			}
		}

		public void AddBankAccount(AbstractBankAccount account)
		{
			if (!Accounts.Contains(account))
			{
				Accounts.Add(account);
				return;
			}

			throw new ArgumentException("This value is already exists.", nameof(account));
		}

		public AbstractBankAccount GetBankAccountByNumber(string number)
		{
			foreach(var account in Accounts)
			{
				if (account.AccountNumber == number)
					return account;
			}

			throw new BankAccountNotFoundException("Account is not found.", nameof(number));
		}

		public void UpdateBankAccount(AbstractBankAccount account)
		{
			for (int i = 0; i < Accounts.Count; i++)
			{
				if (Accounts[i].Equals(account))
				{
					Accounts[i] = account;
					return;
				}
			}

			throw new BankAccountNotFoundException("Account is not found.", nameof(account));
		}

		public void Save()
		{
			Stream stream = File.Create(RepositoryFileName);
			using (var writer = new BinaryWriter(stream))
			{
				writer.Write(Accounts.Count);

				foreach (var account in Accounts)
				{
					writer.Write(account.AccountNumber);
					writer.Write(account.Owner.FirstName);
					writer.Write(account.Owner.LastName);
					writer.Write(account.Balance);
					writer.Write(account.BonusPoints);
					writer.Write((int)account.Status);
					writer.Write((int)account.AccountType);
				}
			}
		}

		private AbstractBankAccount InitializeFields(AbstractBankAccount account, string accountNumber, AccountOwner owner,
			decimal balance, decimal bonusPoints)
		{
			account.AccountNumber = accountNumber;
			account.Owner = owner;
			account.Balance = balance;
			account.BonusPoints = bonusPoints;

			return account;
		}
	}
}
