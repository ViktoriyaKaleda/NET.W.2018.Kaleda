using System;
using System.Collections.Generic;

namespace Fibonacci
{
	/// <summary>
	/// Class that contains method for generating fibonacci sequence.
	/// </summary>
	public static class Fibonacci
    {
		/// <summary>
		/// Generates fibonacci sequence with passed number of elements.
		/// </summary>
		/// <param name="count">The number of elements</param>
		/// <returns>Fibonacci sequence with passed number of elements</returns>
		public static IEnumerable<ulong> Generate(int count)
		{
			if (count < 1)
				throw new ArgumentException("Positive integer number expected.", nameof(count));

			ulong a = 0, b = 1;
			while (count-- > 0)
			{
				ulong temp = b;
				checked
				{
					b = a + b;
				}
				a = temp;
				yield return a;
			}
		}
	}
}
