using System;

namespace Sorting
{
	public static class Sorting
	{
		/// <summary>
		/// Sorts array of integers using quick sort algorithm.
		/// </summary>
		/// <param name="array">Array of integers for sorting</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown when given array is null.
		/// </exception>		
		public static void QuickSort(int[] array)
		{
			CheckArrayOnNull(array);

			QuickSortRealization(array, 0, array.Length - 1);
		}

		/// <summary>
		/// Sorts array of integers using quick sort algorithm.
		/// </summary>
		/// <param name="array">Array of integers for sorting</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort (inclusive).</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown when given array is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown when left or right borders are negative or right border is greater than array length.
		/// </exception>
		public static void QuickSort(int[] array, int left, int right)
		{
			CheckArrayOnNull(array);

			CheckBorders(left, right, array.Length);

			QuickSortRealization(array, left, right);
		}

		/// <summary>
		/// Realization of quick sort algorithm.
		/// </summary>
		/// <param name="array">Array of integers for sorting</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort (inclusive).</param>
		private static void QuickSortRealization(int[] array, int left, int right)
		{
			if (left >= right)
				return;

			int i = left,
				j = right;

			Random random = new Random();
			int pivot = array[random.Next(left, right)];

			while (i <= j)
			{
				// Find element that is to the left of the pivot and is larger than it. 
				while (array[i] < pivot)
					i++;

				// Find element that is to the right of the pivot and is smaller than it. 
				while (array[j] > pivot)
					j--;

				if (i >= j)
					break;

				Swap(ref array[i], ref array[j]);

				i++; j--;
			}

			QuickSortRealization(array, left, j);
			QuickSortRealization(array, j + 1, right);
		}

		/// <summary>
		/// Sorts array of integers using merge sort algorithm.
		/// </summary>
		/// <param name="array">Array of integers for sorting</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown when given array is null.
		/// </exception>
		public static void MergeSort(int[] array)
		{
			CheckArrayOnNull(array);

			MergeSortRealization(array, 0, array.Length - 1);
		}

		/// <summary>
		/// Sorts array of integers using merge sort algorithm.
		/// </summary>
		/// <param name="array">Array of integers for sorting</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort (inclusive).</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown when given array is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown when left or right borders are negative or right border is greater than array length.
		/// </exception>
		public static void MergeSort(int[] array, int left, int right)
		{
			CheckArrayOnNull(array);

			CheckBorders(left, right, array.Length);

			MergeSortRealization(array, 0, array.Length - 1);
		}

		/// <summary>
		/// Realization of merge sort algorithm.
		/// </summary>
		/// <param name="array">Array of integers for sorting</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort (inclusive).</param>
		private static void MergeSortRealization(int[] array, int left, int right)
		{
			if (left >= right)
				return;

			int middle = (left + right + 1) / 2;
			MergeSortRealization(array, left, middle - 1);
			MergeSortRealization(array, middle, right);
			Merge(array, left, middle, right);
		}

		/// <summary>
		/// Merges two subarrays.
		/// </summary>
		/// <param name="array">Array in which range of items are substitute on merged subarrays.</param>
		/// <param name="left">The starting index of the first subarray (i.e. the left border of the array range).</param>
		/// <param name="middle">The starting index of the second subarray (i.e. the middle index of the array range).</param>
		/// <param name="right">The ending index of the second subarray (i.e. the ending index of the array range).</param>
		private static void Merge(int[] array, int left, int middle, int right)
		{
			// Array for result of subarrays merging.
			var resultSubarray = new int[right - left + 1];

			// Indexes for iteration on the first, the second and the result subarrays respectively.
			int i = 0, j = 0, k = 0;

			while (i + left < middle && j + middle <= right)
			{
				// Check which element in the first or second subarray is less and write this element in result subarray.
				if (array[i + left] < array[middle + j])
				{
					resultSubarray[k] = array[i + left];
					i++;
				}
				else
				{
					resultSubarray[k] = array[middle + j];
					j++;
				}
				k++;
			}

			// If there are still elements in the first subarray - write their in result.
			while (i + left < middle)
			{
				resultSubarray[k] = array[i + left];
				k++; i++;
			}

			// If there are still elements in the second subarray - write their in result.
			while (j + middle <= right)
			{
				resultSubarray[k] = array[middle + j];
				k++; j++;
			}

			// Substitute range of items in array on result subarray.
			for (k = 0; k < i + j; k++)
				array[left + k] = resultSubarray[k];
		}

		/// <summary>
		/// Checks if passed array is not null.
		/// </summary>
		/// <param name="array">Array to check.</param>
		private static void CheckArrayOnNull(int[] array)
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array), "The value can not be undefined");
		}

		/// <summary>
		/// Checks if passed left and right borders are valid for array.
		/// </summary>
		/// <param name="left">The starting index of the range.</param>
		/// <param name="right">The ending index of the range.</param>
		/// <param name="length">The length of array.</param>
		private static void CheckBorders(int left, int right, int length)
		{
			if (left < 0 || right < 0)
				throw new ArgumentOutOfRangeException((left < 0 ? nameof(left) : nameof(right)), "A nonnegative number is required.");

			if (right > length - 1)
				throw new ArgumentOutOfRangeException(nameof(right), "Going out of bounds for the array.");
		}

		/// <summary>
		/// Swaps two integer values.
		/// </summary>
		/// <param name="a">First variable to swap.</param>
		/// <param name="b">Second variable to swap.</param>
		private static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}
	}
}
