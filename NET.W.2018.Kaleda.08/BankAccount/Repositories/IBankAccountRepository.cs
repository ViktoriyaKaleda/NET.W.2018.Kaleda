using System.Collections.Generic;
using BankAccount.Entities;

namespace BankAccount.Repositories
{
	public interface IBankAccountRepository
	{
		List<AbstractBankAccount> Accounts { get; }

		void AddBankAccount(AbstractBankAccount account);

		void UpdateBankAccount(AbstractBankAccount account);

		void Save();

		AbstractBankAccount GetBankAccountByNumber(string number);
	}
}
