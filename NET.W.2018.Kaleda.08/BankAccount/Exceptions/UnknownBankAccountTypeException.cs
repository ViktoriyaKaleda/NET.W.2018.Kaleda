using System;
using System.Runtime.Serialization;

namespace BankAccount.Exceptions
{
	class UnknownBankAccountTypeException : ArgumentException
	{
		public UnknownBankAccountTypeException() : base() { }

		public UnknownBankAccountTypeException(string message) : base(message) { }

		public UnknownBankAccountTypeException(string message, string paramName) : base(message, paramName) { }

		public UnknownBankAccountTypeException(string message, Exception innerException) : base(message, innerException) { }

		public UnknownBankAccountTypeException(string message, string paramName, Exception innerException)
			: base(message, paramName, innerException) { }

		public UnknownBankAccountTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
