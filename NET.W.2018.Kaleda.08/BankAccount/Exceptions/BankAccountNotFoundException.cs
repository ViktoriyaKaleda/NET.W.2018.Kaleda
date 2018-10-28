using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Exceptions
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
