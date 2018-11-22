using System;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Exceptions;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class BankAccountServiceTests
	{
		public static Mock<IBankAccountRepository> repositoryMock = new Mock<IBankAccountRepository>();
		public static Mock<INumberGenerator> numberGeneratorMock = new Mock<INumberGenerator>();
		public static BankAccountService service = new BankAccountService(repositoryMock.Object, numberGeneratorMock.Object);

		[Test]
		public void CreateAccount_ValidData_VerifyRepositoryAndNumberGeneratorMethodsCalls()
		{
			repositoryMock.Setup(r => r.AddBankAccount(It.IsAny<BankAccount>()));
			repositoryMock.Setup(r => r.Save());

			numberGeneratorMock.Setup(gen => gen.GetNumber());

			service.CreateNewAccount(Interface.Entities.BankAccountType.BaseBankAccount, new Interface.Entities.AccountOwner());

			repositoryMock.Verify();
			numberGeneratorMock.Verify();

			repositoryMock.Invocations.Clear();
			numberGeneratorMock.Invocations.Clear();
		}
	}
}
