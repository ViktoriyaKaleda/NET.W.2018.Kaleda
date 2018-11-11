using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
	/// <summary>
	/// Simple class that simulates falling numbers in a casino game roulette.
	/// </summary>
	public class Roulette
    {
		/// <summary>
		/// Event that invokes after spin the roulette.
		/// </summary>
		public event EventHandler<RouletteSpinEventArgs> rouletteSpine;

		/// <summary>
		/// Random object that used to get a next roulette number.
		/// </summary>
		private readonly Random random = new Random();

		/// <summary>
		/// Simulates falling number by roulette. Generate event RouletteSpine.
		/// </summary>
		/// <returns>The number that fell.</returns>
		public int Spin()
		{
			int number = random.Next(0, 37);

			rouletteSpine?.Invoke(this, new RouletteSpinEventArgs(number));

			return number;
		}
	}
}
