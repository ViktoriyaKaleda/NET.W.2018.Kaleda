namespace Roulette
{
	/// <summary>
	/// Interface for sending messages.
	/// </summary>
	public interface IMessageSender
	{
		void Send(string message);
	}
}
