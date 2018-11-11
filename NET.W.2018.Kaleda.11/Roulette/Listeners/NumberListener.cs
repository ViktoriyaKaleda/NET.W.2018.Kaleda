using System;

namespace Roulette.Listeners
{
	/// <summary>
	/// Roulette spin listener that send message when specified number fall.
	/// </summary>
	public class NumberListener : IRouletteSpinListener
	{

		public int Number { get; }

		/// <summary>
		/// Object for sending message.
		/// </summary>
		private readonly IMessageSender _messageSender;

		/// <summary>
		/// Initialize <see cref="_messageSender"/> by <see cref="ConsoleMessageSender"/> by default
		/// and <see cref="Number"/> property.
		/// </summary>
		public NumberListener(int number)
		{
			Number = number;
			_messageSender = new ConsoleMessageSender();
		}

		/// <summary>
		/// Sets <see cref="_messageSender"/> object value and <see cref="Number"/> property.
		/// </summary>
		/// <param name="messageSender">The <paramref name="messageSender"/> object.</param>
		public NumberListener(int number, IMessageSender messageSender)
		{
			Number = number;
			_messageSender = messageSender;
		}

		/// <summary>
		/// Sends message when fall specified number.
		/// </summary>
		/// <param name="sender">The roulette that generated event.</param>
		/// <param name="rouletteSpinEventArgs">The roulette spin args.</param>
		private void SendMessageOnRouletteSpin(object sender, RouletteSpinEventArgs rouletteSpinEventArgs)
		{
			if (rouletteSpinEventArgs.Number == Number)
				_messageSender.Send($"Ball fell on {Number}.");
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
