using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public static class Filter
    {
		/// <summary>
		/// Filters the array of numbers and returns array that only contains the specified digit.
		/// </summary>
		/// <param name="digit">Digit which every element in returns array should contains.</param>
		/// <param name="array">Array to filter.</param>
		/// <returns>The filtered array every element of which contains specified digit.</returns>
		public static int[] FilterDigit(int digit, params int[] array)
		{
			CheckParametrs(digit, array);

			List<int> result = new List<int>();
			foreach(var number in array)
			{
				if (ContainsDigit(number, digit))
					result.Add(number);
			}
			return result.ToArray();
		}

		/// <summary>
		/// Checks if passed digit and array are valid.
		/// </summary>
		/// <param name="digit">Digit to filter.</param>
		/// <param name="array">Array to filter.</param>
		private static void CheckParametrs(int digit, int[] array)
		{
			if (digit < 0 || digit > 9)
				throw new ArgumentException("Integer in range from 0 to 9 inclusevly expected.", nameof(digit));

			if (array == null)
				throw new ArgumentNullException(nameof(array), "The value can not be undefined");
		}

		/// <summary>
		/// Returns true if passed number contains specified digit.
		/// </summary>
		/// <param name="number">The number to check.</param>
		/// <param name="digit">The digit for checking.</param>
		/// <returns>True if number contains specified digit, else false.</returns>
		private static bool ContainsDigit(int number, int digit)
		{
			List<int> digits = new List<int>();

			if (number == 0 && digit == 0)
				return true;

			while (number != 0)
			{
				digits.Add(number % 10);
				number /= 10;
			}

			foreach(var d in digits)
			{
				if (d == digit)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Convert list of integers to array.
		/// </summary>
		/// <param name="list">List of integers to convert.</param>
		/// <returns>Array of integers.</returns>
		private static int[] ToArray(List<int> list)
		{
			var array = new int[list.Count];

			for (int i = 0; i < list.Count; i++)
				array[i] = list[i];

			return array;
		}
	}
}
