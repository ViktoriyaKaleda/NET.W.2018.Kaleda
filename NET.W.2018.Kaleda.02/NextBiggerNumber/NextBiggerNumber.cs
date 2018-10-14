using System;
using System.Collections.Generic;
using System.Linq;

namespace NextBiggerNumber
{
	public static class NextBiggerNumber
    {
		/// <summary>
		/// Finds the next bigger number formed by the same digits.
		/// </summary>
		/// <param name="number">Number for find.</param>
		/// <returns>The next bigger number formed by the same digits.</returns>
		public static int FindNextBiggerNumber(int number)
		{
			// Digits of number in reverse order.
			var digits = new List<int>();

			while(number != 0)
			{
				digits.Add(number % 10);
				number /= 10; 
			}

			// Check if result exists.
			int[] sortedDigits = digits.ToArray();
			Array.Sort(sortedDigits);
			if (Enumerable.SequenceEqual(digits, sortedDigits))
				return -1;

			for (int i = 1; i < digits.Count; i++)
			{
				// Looking for the first digit which is smaller than the previous one.
				if (digits[i] < digits[i - 1])
				{
					// Find min digit that bigger than it.
					// Initialize j with value i - 1 bacause in any case we have to swap
					// the found element by index i so if the condition below is never executed, 
					// it will be an element by index i - 1
					int j = i - 1;
					for (int k = 0; k < i; k++)
					{
						if (digits[k] < digits[j] && digits[k] > digits[i])
							j = k;
					}

					// Swap this two items.
					int temp = digits[i];
					digits[i] = digits[j];
					digits[j] = temp;

					// Sort array to position of swapping in reverse order.
					digits.Sort(0, i, Comparer<int>.Default);
					digits.Reverse(0, i);
					break;
				}
			}

			// Get result number from list.
			digits.Reverse();
			return Convert.ToInt32(string.Join("", digits.Select(d => d.ToString())));
		}

		/// <summary>
		/// Finds the next bigger number formed by the same digits and execution time.
		/// </summary>
		/// <param name="number">Number for find.</param>
		/// <param name="executionTime">Time of finding the number.</param>
		/// <returns>The next bigger number formed by the same digits.</returns>
		public static int FindNextBiggerNumberWithExecutionTime(int number, out TimeSpan executionTime)
		{
			var timer = System.Diagnostics.Stopwatch.StartNew();

			int result = FindNextBiggerNumber(number);

			timer.Stop();

			executionTime = timer.Elapsed;

			return result;
		}

		/// <summary>
		/// Finds the next bigger number formed by the same digits and execution time.
		/// </summary>
		/// <param name="number">Number for find.</param>
		/// <returns>Tuple of two values: the next bigger number formed by the same digits and execution time.</returns>
		public static (int result, TimeSpan executionTime) FindNextBiggerNumberWithExecutionTime(int number)
		{
			var timer = System.Diagnostics.Stopwatch.StartNew();

			int result = FindNextBiggerNumber(number);

			timer.Stop();

			return (result, timer.Elapsed);
		}
	}
}
