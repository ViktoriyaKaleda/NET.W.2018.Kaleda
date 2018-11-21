using System;
using System.Runtime.Serialization;

namespace DAL.Fake.Exceptions
{
	class BankAccountNotFoundException : ArgumentException
	{
		public BankAccountNotFoundException() : base() { }

		public BankAccountNotFoundException(string message) : base(message) { }

		public BankAccountNotFoundException(string message, string paramName) : base(message, paramName) { }

		public BankAccountNotFoundException(string message, Exception innerException) : base(message, innerException) { }

		public BankAccountNotFoundException(string message, string paramName, Exception innerException) 
			: base(message, paramName, innerException) { }

		public BankAccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
