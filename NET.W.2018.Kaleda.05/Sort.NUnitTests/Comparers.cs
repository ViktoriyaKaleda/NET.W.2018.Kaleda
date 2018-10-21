using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.NUnitTests
{
	/// <summary>
	/// Class that contains comparers for sorting jagged arrays.
	/// </summary>
	public class Comparers
	{
		/// <summary>
		/// Comparer for sorting by ascending max sums of rows.
		/// </summary>
		public class ByAscendingRowElementsSums : IComparer<int[]>
		{
			public int Compare(int[] first, int[] second)
			{
				CheckParameters(first, second);

				int firstSum = first.Sum(),
					secondSum = second.Sum();

				if (firstSum == secondSum)
					return 0;

				return firstSum > secondSum ? 1 : -1;
			}
		}

		/// <summary>
		/// Comparer for sorting by descending max sums of rows.
		/// </summary>
		public class ByDescendingRowElementsSums : IComparer<int[]>
		{
			public int Compare(int[] first, int[] second)
			{
				CheckParameters(first, second);

				int firstSum = first.Sum(),
					secondSum = second.Sum();

				if (firstSum == secondSum)
					return 0;

				return firstSum > secondSum ? -1 : 1;
			}
		}

		/// <summary>
		/// Comparer for sorting by ascendibg max element of the row.
		/// </summary>
		public class ByAscendingMaxElements : IComparer<int[]>
		{
			public int Compare(int[] first, int[] second)
			{
				CheckParameters(first, second);

				int firstMax = first.Max(),
					secondMax = second.Max();

				if (firstMax == secondMax)
					return 0;

				return firstMax > secondMax ? 1 : -1;
			}
		}

		/// <summary>
		/// Comparer for sorting by descending max element of the row.
		/// </summary>
		public class ByDescendingMaxElements : IComparer<int[]>
		{
			public int Compare(int[] first, int[] second)
			{
				CheckParameters(first, second);

				int firstMax = first.Max(),
					secondMax = second.Max();

				if (firstMax == secondMax)
					return 0;

				return firstMax > secondMax ? -1 : 1;
			}
		}

		/// <summary>
		/// Comparer for sorting by ascendibg min element of the row.
		/// </summary>
		public class ByAscendingMinElements : IComparer<int[]>
		{
			public int Compare(int[] first, int[] second)
			{
				CheckParameters(first, second);

				int firstMin = first.Min(),
					secondMin = second.Min();

				if (firstMin == secondMin)
					return 0;

				return firstMin > secondMin ? 1 : -1;
			}
		}

		/// <summary>
		/// Comparer for sorting by descending max element of the row.
		/// </summary>
		public class ByDescendingMinElements : IComparer<int[]>
		{
			public int Compare(int[] first, int[] second)
			{
				CheckParameters(first, second);

				int firstMin = first.Min(),
					secondMin = second.Min();

				if (firstMin == secondMin)
					return 0;

				return firstMin > secondMin ? -1 : 1;
			}
		}

		/// <summary>
		/// Chacks if passed arrays are not null.
		/// </summary>
		/// <param name="first">The first array.</param>
		/// <param name="second">The second array.</param>
		/// <exception cref="ArgumentNullException">Throws when array is null.</exception>
		private static void CheckParameters(int[] first, int[] second)
		{
			if (first == null || second == null)
				throw new ArgumentNullException(first == null ? nameof(first) : nameof(second), "Value can not be undefined.");
		}

	}
}
