using System;
using System.Linq;

namespace Roulette
{
	/// <summary>
	/// Class that stores an information about roulette spin event args.
	/// </summary>
	public class RouletteSpinEventArgs : EventArgs
	{
		/// <summary>
		/// The number that fell.
		/// </summary>
		public int Number { get; }

		/// <summary>
		/// The color of the number.
		/// </summary>
		public CellColor Color { get; }

		/// <summary>
		/// Numbers that are red.
		/// </summary>
		private static int[] RedColorNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

		/// <summary>
		/// Set number and color of spin result.
		/// </summary>
		/// <param name="number"></param>
		public RouletteSpinEventArgs(int number)
		{
			Number = number;
			if (number == 0)
				Color = CellColor.Green;
			else
				Color = RedColorNumbers.Contains(number) ? CellColor.Red : CellColor.Black;
		}
	}
}
