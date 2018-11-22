using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Factories;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappers
{
	public static class EntitiesMapper
	{
		public static List<AbstractBankAccount> ToAbstractBankAccountList(List<DAL.Interface.DTO.BankAccount> accounts)
		{
			return accounts.Select((m) =>
			{
				var result = BankAccountFactory.Create(Mapper.Map<BankAccountType>(m.AccountType), m.AccountNumber);
				result.Owner = Mapper.Map<AccountOwner>(m.Owner);
				result.Balance = m.Balance;
				result.BonusPoints = m.BonusPoints;
				return result;
			}).ToList();
		}

		public static DAL.Interface.DTO.BankAccount ToDtoBankAccont(AbstractBankAccount account)
		{
			var result = DAL.Interface.Factories.BankAccountFactory.Create(
				(DAL.Interface.DTO.BankAccountType)(int)account.AccountType, account.AccountNumber);
			result.Owner = Mapper.Map<DAL.Interface.DTO.AccountOwner>(account.Owner);
			result.Balance = account.Balance;
			result.BonusPoints = account.BonusPoints;
			return result;
		}
	}
}
