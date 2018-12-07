using DAL.Interface.DTO;
using DAL.Interface.Exceptions;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
	public class EFRepository : IBankAccountRepository
	{
		public List<BankAccount> Accounts
		{
			get
			{
				using (var context = new BankAccountContext())
					return context.BankAccounts.Include(m => m.Owner).ToList();
			}
		}

		public void AddBankAccount(BankAccount account)
		{
			using (var context = new BankAccountContext())
			{
				var bankAccount = context.BankAccounts.FirstOrDefault(m => m.AccountNumber == account.AccountNumber);

				if (bankAccount == null)
				{
					context.BankAccounts.Add(account);

					var accountOwner = context.Owners.FirstOrDefault(m => m.AccountOwnerId == account.Owner.AccountOwnerId);
					if (accountOwner == null)
						context.Owners.Add(account.Owner);

					context.SaveChanges();
					return;
				}					
			}				

			throw new ArgumentException("This value is already exists.", nameof(account));
		}

		public BankAccount GetBankAccountByNumber(string number)
		{
			using (var context = new BankAccountContext())
			{
				var bankAccount = context.BankAccounts.FirstOrDefault(m => m.AccountNumber == number);

				if (bankAccount == null)
					throw new BankAccountNotFoundException("Account is not found.", nameof(number));

				return bankAccount;
			}				
		}

		public void Save()
		{
			using (var context = new BankAccountContext())
				context.SaveChanges();
		}

		public void UpdateBankAccount(BankAccount account)
		{
			using (var context = new BankAccountContext())
			{
				var bankAccount = context.BankAccounts.FirstOrDefault(m => m.AccountNumber == account.AccountNumber);

				if (bankAccount == null)
					throw new BankAccountNotFoundException("Account is not found.", nameof(account));

				bankAccount.Balance = account.Balance;
				bankAccount.BonusPoints = account.BonusPoints;
				bankAccount.Status = account.Status;

				context.SaveChanges();
			}
		}
	}
}
