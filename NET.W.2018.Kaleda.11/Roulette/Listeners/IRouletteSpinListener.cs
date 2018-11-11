namespace Roulette.Listeners
{
	/// <summary>
	/// Interface for listening Roulette spin event.
	/// </summary>
	public interface IRouletteSpinListener
	{
		void Subscribe(Roulette roulette);
		void Unsubscribe(Roulette roulette);
	}
}
