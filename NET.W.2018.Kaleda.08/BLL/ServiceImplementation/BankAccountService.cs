using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Factories;
using BLL.Interface.Interfaces;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.ServiceImplementation
{
	public class BankAccountService : IBankAccountService
	{
		private readonly IBankAccountRepository _repository;
		private readonly INumberGenerator _numberGenerator;

		public List<AbstractBankAccount> Accounts { get => EntitiesMapper.ToAbstractBankAccountList(_repository.Accounts); }

		public BankAccountService(IBankAccountRepository repository, INumberGenerator numberGenerator)
		{
			_repository = repository;
			_numberGenerator = numberGenerator;
			Mapper.Initialize(c => c.AddProfile<MappingProfile>());
		}

		public void CloseAccount(string accountNumber)
		{
			var account = Mapper.Map<AbstractBankAccount>(_repository.GetBankAccountByNumber(accountNumber));
			account.Close();
			_repository.UpdateBankAccount(Mapper.Map<DAL.Interface.DTO.BankAccount>(account));
			_repository.Save();
		}

		public string CreateNewAccount(BankAccountType accountType, AccountOwner owner, decimal balance = 0, decimal bonusPoints = 0)
		{
			if (owner == null)
				throw new ArgumentNullException(nameof(owner), "Value can not be undefined.");

			AbstractBankAccount newAccount = BankAccountFactory.Create(accountType, _numberGenerator.GetNumber());
			newAccount.Owner = owner;
			newAccount.Balance = balance;
			newAccount.BonusPoints = bonusPoints;
			var a = EntitiesMapper.ToDtoBankAccont(newAccount);
			_repository.AddBankAccount(a);
			_repository.Save();

			return newAccount.AccountNumber;
		}

		public void Deposit(string accountNumber, decimal sum)
		{
			var account = Mapper.Map<AbstractBankAccount>(_repository.GetBankAccountByNumber(accountNumber));
			account.Deposit(sum);
			_repository.UpdateBankAccount(Mapper.Map<DAL.Interface.DTO.BankAccount>(account));
			_repository.Save();
		}

		public void Withdraw(string accountNumber, decimal sum)
		{
			var account = Mapper.Map<AbstractBankAccount>(_repository.GetBankAccountByNumber(accountNumber));
			account.Withdraw(sum);
			_repository.UpdateBankAccount(Mapper.Map<DAL.Interface.DTO.BankAccount>(account));
			_repository.Save();
		}
	}
}
