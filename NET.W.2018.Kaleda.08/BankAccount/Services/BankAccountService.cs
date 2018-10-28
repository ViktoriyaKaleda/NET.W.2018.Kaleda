using BankAccount.Entities;
using BankAccount.Exceptions;
using BankAccount.Repositories;
using System;
using System.Collections.Generic;

namespace BankAccount.Services
{
	public class BankAccountService : IBankAccountService
	{
		private readonly IBankAccountRepository _repository;

		public List<AbstractBankAccount> Accounts { get => _repository.Accounts; }

		public BankAccountService(IBankAccountRepository repository)
		{
			_repository = repository;
		}

		public void CloseAccount(string accountNumber)
		{
			var account = _repository.GetBankAccountByNumber(accountNumber);
			account.Close();
			_repository.UpdateBankAccount(account);
			_repository.Save();
		}

		public string CreateNewAccount(BankAccountType accountType, AccountOwner owner, decimal balance = 0, decimal bonusPoints = 0)
		{
			if (owner == null)
				throw new ArgumentNullException(nameof(owner), "Value can not be undefined.");

			AbstractBankAccount newAccount;
			switch (accountType)
			{				
				case BankAccountType.Base:
					_repository.AddBankAccount(newAccount = new BaseBankAccount(owner, balance, bonusPoints));
					_repository.Save();
					break;

				case BankAccountType.Gold:
					_repository.AddBankAccount(newAccount = new GoldBankAccount(owner, balance, bonusPoints));
					_repository.Save();
					break;

				case BankAccountType.Platinum:
					_repository.AddBankAccount(newAccount = new PlatinumBankAccount(owner, balance, bonusPoints));
					_repository.Save();
					break;

				default:
					throw new UnknownBankAccountTypeException("Unknown account type passed.", nameof(accountType));
			}

			return newAccount.AccountNumber;
		}

		public void Deposit(string accountNumber, decimal sum)
		{
			var account = _repository.GetBankAccountByNumber(accountNumber);
			account.Deposit(sum);
			_repository.UpdateBankAccount(account);
			_repository.Save();
		}

		public void Withdraw(string accountNumber, decimal sum)
		{
			var account = _repository.GetBankAccountByNumber(accountNumber);
			account.Withdraw(sum);
			_repository.UpdateBankAccount(account);
			_repository.Save();
		}
	}
}
