namespace Roulette.Listeners
{
	/// <summary>
	/// Roulette spin listener that send message when black number fall.
	/// </summary>
	public class BlackNumbersListener : IRouletteSpinListener
	{
		/// <summary>
		/// Object for sending message.
		/// </summary>
		private readonly IMessageSender _messageSender;

		/// <summary>
		/// Initialize <see cref="_messageSender"/> by <see cref="ConsoleMessageSender"/> by default.
		/// </summary>
		public BlackNumbersListener()
		{
			_messageSender = new ConsoleMessageSender();
		}

		/// <summary>
		/// Sets <see cref="_messageSender"/> object value.
		/// </summary>
		/// <param name="messageSender">The <paramref name="messageSender"/> object.</param>
		public BlackNumbersListener(IMessageSender messageSender)
		{
			_messageSender = messageSender;
		}

		/// <summary>
		/// Sends message when fall black number.
		/// </summary>
		/// <param name="sender">The roulette that generated event.</param>
		/// <param name="rouletteSpinEventArgs">The roulette spin args.</param>
		private void SendMessageOnRouletteSpin(object sender, RouletteSpinEventArgs rouletteSpinEventArgs)
		{
			if (rouletteSpinEventArgs.Color == CellColor.Black)
				_messageSender.Send($"Ball fell on black {rouletteSpinEventArgs.Number}.");
		}

		/// <summary>
		/// Subscribes on the roulette spin event.
		/// </summary>
		/// <param name="roulette">The roulette for subscription.</param>
		public void Subscribe(Roulette roulette)
		{
			roulette.rouletteSpine += SendMessageOnRouletteSpin;
		}

		/// <summary>
		/// Unsubscribes on the roulette spin event.
		/// </summary>
		/// <param name="roulette">The roulette for unsubscription.</param>
		public void Unsubscribe(Roulette roulette)
		{
			roulette.rouletteSpine -= SendMessageOnRouletteSpin;
		}
	}
}
