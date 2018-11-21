using BLL.Interface.Interfaces;
using System;

namespace BLL.ServiceImplementation
{
	public class NumberGenerator : INumberGenerator
	{
		public string GetNumber()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
