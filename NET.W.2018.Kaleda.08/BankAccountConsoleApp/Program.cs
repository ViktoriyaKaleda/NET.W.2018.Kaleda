using System;
using System.Collections.Generic;
using BankAccount.Entities;
using BankAccount.Repositories;
using BankAccount.Services;

namespace BankAccountConsoleApp
{
	class Program
	{
		public static IBankAccountService BankAccountService { get; set; }

		static Program()
		{
			BankAccountService = new BankAccountService(new BankAccountRepository());
		}

		static void Main(string[] args)
		{
			var owner1 = new AccountOwner()
			{
				FirstName = "Viktoriya",
				LastName = "Kaleda",
			};

			var owner2 = new AccountOwner()
			{
				FirstName = "Ivan",
				LastName = "Ivanov",
			};

			var accountsNumbers = new List<string>()
			{
				BankAccountService.CreateNewAccount(BankAccountType.Base, owner1),
				BankAccountService.CreateNewAccount(BankAccountType.Gold, owner1, balance: 200),
				BankAccountService.CreateNewAccount(BankAccountType.Platinum, owner2, balance: 100),
			};

			PrintAccountsInfo();

			foreach (var number in accountsNumbers)
			{
				BankAccountService.Deposit(number, 150);
			}

			foreach (var number in accountsNumbers)
			{
				BankAccountService.Withdraw(number, 50);
			}

			PrintAccountsInfo();

			BankAccountService.CloseAccount(accountsNumbers[0]);

			PrintAccountsInfo();
		}

		public static void PrintAccountsInfo()
		{
			foreach (var account in BankAccountService.Accounts)
			{
				Console.WriteLine(account);
				Console.WriteLine();
			}
		}
	}
}
