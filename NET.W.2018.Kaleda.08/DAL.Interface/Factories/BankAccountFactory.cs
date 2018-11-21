using System;
using DAL.Interface.DTO;

namespace DAL.Interface.Factories
{
	public static class BankAccountFactory
	{
		public static BankAccount Create(BankAccountType typeName, string number)
		{
			Type type = Type.GetType(typeName.ToString());
			return (BankAccount)Activator.CreateInstance(type, number);
		}
	}
}
