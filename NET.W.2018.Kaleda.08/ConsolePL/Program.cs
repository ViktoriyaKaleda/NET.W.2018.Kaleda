using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Interface.Services;
using DAL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using System;
using Ninject.Parameters;
using DAL.Interface.Exceptions;

namespace ConsolePL
{
	class Program
	{
		private static readonly IKernel _resolver;

		static Program()
		{
			_resolver = new StandardKernel();
			_resolver.ConfigurateResolver();			
		}

		static void Main(string[] args)
		{
			IBankAccountService _bankAccountService;

			_bankAccountService = _resolver.Get<IBankAccountService>(
				new ConstructorArgument("repository", _resolver.Get<IBankAccountRepository>()),
				new ConstructorArgument("numberGenerator", _resolver.Get<INumberGenerator>()));

			while (true)
			{
				Console.WriteLine("1. Add base account");
				Console.WriteLine("2. Add gold account");
				Console.WriteLine("3. Add platinum account");
				Console.WriteLine("4. Print list of accounts");
				Console.WriteLine("5. Wirthdraw money");
				Console.WriteLine("6. Deposit money");
				Console.WriteLine("7. Exit");

				ConsoleKeyInfo choose = Console.ReadKey();
				Console.Clear();

				if (choose.KeyChar == '1')
				{
					Console.WriteLine(String.Format("Base account with number {0} was created.",
						_bankAccountService.CreateNewAccount(BankAccountType.BaseBankAccount, new AccountOwner()
						{
							FirstName = Console.ReadLine(),
							LastName = Console.ReadLine()
						}))
					);
				}

				else if (choose.KeyChar == '2')
				{
					Console.WriteLine(String.Format("Gold account with number {0} was created.",
						_bankAccountService.CreateNewAccount(BankAccountType.GoldBankAccount, new AccountOwner()
						{
							FirstName = Console.ReadLine(),
							LastName = Console.ReadLine()
						}))
					);
				}

				else if (choose.KeyChar == '3')
				{
					Console.WriteLine(String.Format("Platinum account with number {0} was created.",
						_bankAccountService.CreateNewAccount(BankAccountType.PlatinumBankAccount, new AccountOwner()
						{
							FirstName = Console.ReadLine(),
							LastName = Console.ReadLine()
						}))
					);
				}

				else if (choose.KeyChar == '4')
				{
					PrintAccountsInfo(_bankAccountService);
				}

				else if (choose.KeyChar == '5')
				{
					Console.WriteLine();
					_bankAccountService.Withdraw(
						Console.ReadLine(),
						decimal.Parse(Console.ReadLine()));
				}

				else if (choose.KeyChar == '6')
				{
					Console.WriteLine();
					_bankAccountService.Deposit(
						Console.ReadLine(),
						decimal.Parse(Console.ReadLine()));
				}

				else if (choose.KeyChar == '7')
					break;
			}
		}

		public static void PrintAccountsInfo(IBankAccountService _bankAccountService)
		{
			Console.WriteLine();
			Console.WriteLine("Bank accounts: ");
			foreach (var account in _bankAccountService.Accounts)
			{
				Console.WriteLine(account);
				Console.WriteLine();
			}
		}
	}
}
