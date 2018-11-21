using System;
using BLL.Interface.Entities;

namespace BLL.Interface.Factories
{
	public static class BankAccountFactory
	{
		public static AbstractBankAccount Create(BankAccountType typeName, string number)
		{
		//	var baseType = typeof(AbstractBankAccount).Namespace
			Type type = Type.GetType(typeof(AbstractBankAccount).Namespace + "." + typeName.ToString());
			return (AbstractBankAccount)Activator.CreateInstance(type, number);
		}
	}
}
