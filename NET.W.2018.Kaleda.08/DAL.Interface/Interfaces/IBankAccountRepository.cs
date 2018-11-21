using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
	public interface IBankAccountRepository
	{
		List<BankAccount> Accounts { get; }

		void AddBankAccount(BankAccount account);

		void UpdateBankAccount(BankAccount account);

		void Save();

		BankAccount GetBankAccountByNumber(string number);
	}
}
