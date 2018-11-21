using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
	public interface IBankAccountService
	{ 
		List<AbstractBankAccount> Accounts { get; }

		string CreateNewAccount(BankAccountType accauntType, AccountOwner owner, decimal balance = 0, decimal bonusPoints = 0);

		void CloseAccount(string accountNumber);

		void Deposit(string accountNumber, decimal sum);

		void Withdraw(string accountNumber, decimal sum);
	}
}
