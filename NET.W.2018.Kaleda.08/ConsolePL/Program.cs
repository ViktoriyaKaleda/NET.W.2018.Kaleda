using BLL.Interface.Entities;
using BLL.Interface.Services;
using DependencyResolver;
using Ninject;
using System;
using System.Collections.Generic;

namespace ConsolePL
{
	class Program
	{
		private static readonly IKernel _resolver;
		private static IBankAccountService _bankAccountService;

		static Program()
		{
			_resolver = new StandardKernel();
			_resolver.ConfigurateResolver();
			_bankAccountService = _resolver.Get<IBankAccountService>();
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
				_bankAccountService.CreateNewAccount(BankAccountType.BaseBankAccount, owner1),
				_bankAccountService.CreateNewAccount(BankAccountType.GoldBankAccount, owner1, balance: 200),
				_bankAccountService.CreateNewAccount(BankAccountType.PlatinumBankAccount, owner2, balance: 100),
			};

			PrintAccountsInfo();

			foreach (var number in accountsNumbers)
			{
				_bankAccountService.Deposit(number, 150);
			}

			foreach (var number in accountsNumbers)
			{
				_bankAccountService.Withdraw(number, 50);
			}

			PrintAccountsInfo();

			_bankAccountService.CloseAccount(accountsNumbers[0]);

			PrintAccountsInfo();
		}

		public static void PrintAccountsInfo()
		{
			foreach (var account in _bankAccountService.Accounts)
			{
				Console.WriteLine(account);
				Console.WriteLine();
			}
		}
	}
}
