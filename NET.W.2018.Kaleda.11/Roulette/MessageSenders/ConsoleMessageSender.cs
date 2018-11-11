using System;

namespace Roulette
{
	/// <summary>
	/// Realization of sending messages in console application.
	/// </summary>
	public class ConsoleMessageSender : IMessageSender
	{
		public void Send(string message)
		{
			Console.WriteLine(message);
		}
	}
}
