using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public static class Filter
    {
		public static int[] FilterDigit(int digit, params int[] list)
		{
			CheckParametrs(digit, list);

			List<int> result = new List<int>();
			foreach(var number in list)
			{
				if (ContainsDigit(number, digit))
					result.Add(number);
			}
			return result.ToArray();
		}

		private static void CheckParametrs(int digit, int[] list)
		{
			if (digit < 0 || digit > 9)
				throw new ArgumentException("Integer in range from 0 to 9 inclusevly expected.", nameof(digit));

			if (list == null)
				throw new ArgumentNullException(nameof(list), "The value can not be undefined");
		}

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

		private static int[] ToArray(List<int> list)
		{
			var array = new int[list.Count];

			for (int i = 0; i < list.Count; i++)
				array[i] = list[i];

			return array;
		}
	}
}
