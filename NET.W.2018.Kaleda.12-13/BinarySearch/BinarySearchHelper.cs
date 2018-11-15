using System;
using System.Collections.Generic;

namespace BinarySearch
{
	/// <summary>
	/// Class that contains methods for searching elements in array using binary search algorithm.
	/// </summary>
	public static class BinarySearchHelper
    {
		/// <summary>
		/// Returns index of the given element or -1 if it is not exists. If comparer is null, elements of
		/// the list are compared to the search value using the IComparable interface. This method assumes 
		/// that the given section of the list is already sorted; if not, the result will be incorrect.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The source array.</param>
		/// <param name="index">The start index in array for search.</param>
		/// <param name="count">The number of elements in source array for search.</param>
		/// <param name="item">The item for search.</param>
		/// <param name="comparer">The comparer.</param>
		/// <exception cref="ArgumentOutOfRangeException">Throws when passed index or 
		/// count are negative.</exception>
		/// <exception cref="ArgumentException">Throws when invalid interval for search are passed.</exception>
		/// <returns>Returns index of the given element or -1 if it is not exists.</returns>
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

		/// <summary>
		/// Returns index of the given element or -1 if it is not exists. This method uses default comparer. This method assumes 
		/// that the given section of the list is already sorted; if not, the result will be incorrect.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The source array.</param>
		/// <param name="item">The item for search.</param>
		/// <returns></returns>
		public static int BinarySearch<T>(this T[] items, T item)
		{
			CheckArrayOnNull<T>(items);

			IComparer<T> comparer = Comparer<T>.Default;

			return Search(items, 0, items.Length, item, comparer);
		}

		/// <summary>
		///Returns index of the given element or -1 if it is not exists. This method uses default comparer. This method assumes 
		/// that the given section of the list is already sorted; if not, the result will be incorrect.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The source array.</param>
		/// <param name="item">The item for search.</param>
		/// <param name="comparer">The comparer.</param>
		/// <returns></returns>
		public static int BinarySearch<T>(this T[] items, T item, IComparer<T> comparer)
		{
			CheckArrayOnNull<T>(items);

			if (comparer == null)
				comparer = Comparer<T>.Default;

			return Search(items, 0, items.Length, item, comparer);
		}

		/// <summary>
		/// The realization of binary search algorithm. This method assumes 
		/// that the given section of the list is already sorted; if not, the result will be incorrect.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The source array.</param>
		/// <param name="index">The start index in array for search.</param>
		/// <param name="count">The number of elements in source array for search.</param>
		/// <param name="item">The item for search.</param>
		/// <param name="comparer">The comparer.</param>
		/// <returns></returns>
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

		/// <summary>
		/// Checks if passed array is not null.
		/// </summary>
		/// <param name="items">Array to check.</param>
		private static void CheckArrayOnNull<T>(T[] items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items), "Value can not be null.");
		}
	}
}
