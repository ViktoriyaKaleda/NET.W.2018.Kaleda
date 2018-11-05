using System;
using System.Collections.Generic;

namespace BubbleSort
{
	/// <summary>
	/// Class for sorting jagged arrays.
	/// </summary>
	public static class BubbleSort
	{
		/// <summary>
		/// Sorts jagged array.
		/// </summary>
		/// <param name="array">The array to sort.</param>
		/// <param name="comparer">Comparer which contains sorting logic.</param>
		/// <exception cref="ArgumentNullException">Throws when array or comparer are null.</exception>
		/// <exception cref="ArgumentException">Throws when array is empty.</exception>
		public static void Sort(int[][] array, IComparer<int[]> comparer)
		{
			if (array == null || comparer == null)
				throw new ArgumentNullException(array == null ? nameof(array) : nameof(comparer), "The value can not be undefined.");

			if (array.Length == 0)
				throw new ArgumentException("Value can not be empty.", nameof(array));

			SortRealization(array, comparer.Compare);
		}

		/// <summary>
		/// Bumble sorting realization.
		/// </summary>
		/// <param name="array">The array to sort.</param>
		/// <param name="comparison">Comparison which contains sorting logic.</param>
		private static void SortRealization(int[][] array, Comparison<int[]> comparison)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - 1; j++)
				{
					if (comparison(array[j], array[j + 1]) > 0)
						Swap(ref array[j], ref array[j + 1]);
				}
			}
		}

		/// <summary>
		/// Sorts jagged array.
		/// </summary>
		/// <param name="array">The array to sort.</param>
		/// <param name="comparison">Comparison which contains sorting logic.</param>
		/// <exception cref="ArgumentNullException">Throws when array or comparison are null.</exception>
		/// <exception cref="ArgumentException">Throws when array is empty.</exception>
		public static void Sort(int[][] array, Comparison<int[]> comparison)
		{
			if (array == null || comparison == null)
				throw new ArgumentNullException(array == null ? nameof(array) : nameof(comparison), "The value can not be undefined.");

			if (array.Length == 0)
				throw new ArgumentException("Value can not be empty.", nameof(array));

			SortRealization(array, Comparer<int[]>.Create(comparison));
		}

		/// <summary>
		/// Bumble sorting realization.
		/// </summary>
		/// <param name="array">The array to sort.</param>
		/// <param name="comparer">Comparer which contains sorting logic.</param>
		private static void SortRealization(int[][] array, IComparer<int[]> comparer)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - 1; j++)
				{
					if (comparer.Compare(array[j], array[j + 1]) > 0)
						Swap(ref array[j], ref array[j + 1]);
				}
			}
		}

		/// <summary>
		/// Swaps two arrays.
		/// </summary>
		/// <param name="a">The first array.</param>
		/// <param name="b">The second array.</param>
		private static void Swap(ref int[] a, ref int[] b)
		{
			var temp = a;
			a = b;
			b = temp;
		}
	}
}
