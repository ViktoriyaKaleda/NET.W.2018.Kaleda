using System;
using System.Collections.Generic;

namespace BinarySearch
{
	public static class BinarySearchHelper
    {
		public static int BinarySearch<T>(this T[] items, int index, int count, T item, IComparer<T> comparer)
		{
			if (index < 0 || count < 0)
				throw new ArgumentOutOfRangeException(index < 0 ? nameof(index) : nameof(count), "A nonnegative number is required.");

			if (items.Length - index < count)
				throw new ArgumentException("Invalid search interval.");

			CheckArrayOnNull<T>(items);

			if (comparer == null)
				comparer = Comparer<T>.Default;

			return Search(items, index, count, item, comparer);
		}

		public static int BinarySearch<T>(this T[] items, T item)
		{
			CheckArrayOnNull<T>(items);

			IComparer<T> comparer = Comparer<T>.Default;

			return Search(items, 0, items.Length, item, comparer);
		}

		public static int BinarySearch<T>(this T[] items, T item, IComparer<T> comparer)
		{
			CheckArrayOnNull<T>(items);

			if (comparer == null)
				comparer = Comparer<T>.Default;

			return Search(items, 0, items.Length, item, comparer);
		}

		private static int Search<T>(T[] items, int index, int count, T item, IComparer<T> comparer)
		{
			int left = index;
			int right = index + count - 1;

			while (left <= right)
			{
				int i = left + ((right - left) / 2);
				int comparisonResult = comparer.Compare(items[i], item);

				if (comparisonResult == 0)
					return i;

				if (comparisonResult < 0)
					left = i + 1;

				else
					right = i - 1;
			}

			return ~left;
		}

		private static void CheckArrayOnNull<T>(T[] items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items), "Value can not be null.");
		}
	}
}
