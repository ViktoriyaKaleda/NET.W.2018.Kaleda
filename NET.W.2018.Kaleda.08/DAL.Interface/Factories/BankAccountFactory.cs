using System;
using DAL.Interface.DTO;

namespace DAL.Interface.Factories
{
	public static class BankAccountFactory
	{
		public static BankAccount Create(BankAccountType typeName, string number)
		{
			Type type = Type.GetType(typeof(BankAccount).Namespace + "." + typeName.ToString());
			return (BankAccount)Activator.CreateInstance(type, number);
		}
	}
}
