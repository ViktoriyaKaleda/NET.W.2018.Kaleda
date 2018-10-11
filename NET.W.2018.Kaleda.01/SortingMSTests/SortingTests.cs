using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Sorting.Sorting;

namespace SortingMSTests
{
	[TestClass]
	public class SortingTests
	{
		[TestMethod]
		[DataRow(new int[] { }, new int[] { })]
		[DataRow(new int[] { 1 }, new int[] { 1 })]
		[DataRow(new int[] { 0, 1}, new int[] { 0, 1})]
		[DataRow(new int[] { 1, -5, 0 }, new int[] { -5, 0, 1 })]
		[DataRow(new int[] { 5, 2, -1, 1, 4, 3}, new int[] { -1, 1, 2, 3, 4, 5})]		
		public void QuickSort_SortingValidArray_SortedArray(int[] array, int[] expectedResult)
		{
			QuickSort(array);
			CollectionAssert.AreEqual(array, expectedResult);
		}

		[TestMethod]
		[DataRow(new int[] { 1 }, 0, 0, new int[] { 1 })]
		[DataRow(new int[] { 1, 0 }, 0, 0, new int[] { 1, 0 })]
		[DataRow(new int[] { 1, -5, 0 }, 0, 1, new int[] { -5, 1, 0 })]
		[DataRow(new int[] { 5, 2, -1, 1, 4, 3 }, 2, 5, new int[] { 5, 2, -1, 1, 3, 4 })]
		public void QuickSort_SortingSubarray_SortedSubarray(int[] array, int left, int right, int[] expectedResult)
		{
			QuickSort(array, left, right);
			CollectionAssert.AreEqual(array, expectedResult);
		}

		[TestMethod]
		public void QuickSort_SortingBigArray_SortedBigArray()
		{
			// Generate array of random integers
			Random r = new Random();
			int[] array = Enumerable.Range(-1000000, 1000000)
				.Select(_ => r.Next(0, 100))
				.ToArray(),
				expectedResult = new int[array.Length];

			// Get two equals array's objects
			Array.Copy(array, expectedResult, array.Length);

			// Sort the first with build-in method
			Array.Sort(expectedResult);

			// Sort the second with testing method
			QuickSort(array);

			CollectionAssert.AreEqual(array, expectedResult);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void QuickSort_NullArray_ArgumentNullException()
		{
			int[] array = null;
			QuickSort(array);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		[DataRow(new int[] { 1, 2, 3, }, -1, 1)]
		[DataRow(new int[] { 1, 2, 3, }, 0, -1)]
		[DataRow(new int[] { 1, 2, 3, }, -1, -1)]
		[DataRow(new int[] { 1, 2, 3, }, -1, 10)]
		[DataRow(new int[] { 1, 2, 3, }, 0, 10)]
		public void QuickSort_InvalidBordersValuesPassed_ArgumentOutOfRangeException(int[] array, int left, int right)
		{
			QuickSort(array, left, right);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void QuickSort_LeftBorderLargerThanRight_ArgumentException()
		{
			QuickSort(new int[] { 1, 2, 3}, 1, 0);
		}

		[TestMethod]
		[DataRow(new int[] { }, new int[] { })]
		[DataRow(new int[] { 1 }, new int[] { 1 })]
		[DataRow(new int[] { 0, 1 }, new int[] { 0, 1 })]
		[DataRow(new int[] { 1, -5, 0 }, new int[] { -5, 0, 1 })]
		[DataRow(new int[] { 5, 2, -1, 1, 4, 3 }, new int[] { -1, 1, 2, 3, 4, 5 })]
		public void MergeSort_SortingValidArray_SortedArray(int[] array, int[] expectedResult)
		{
			MergeSort(array);
			CollectionAssert.AreEqual(array, expectedResult);
		}

		[TestMethod]
		[DataRow(new int[] { 1 }, 0, 0, new int[] { 1 })]
		[DataRow(new int[] { 1, 0 }, 0, 0, new int[] { 1, 0 })]
		[DataRow(new int[] { 1, -5, 0 }, 0, 1, new int[] { -5, 1, 0 })]
		[DataRow(new int[] { 5, 2, -1, 1, 4, 3 }, 2, 5, new int[] { 5, 2, -1, 1, 3, 4 })]
		public void MergeSort_SortingSubarray_SortedSubarray(int[] array, int left, int right, int[] expectedResult)
		{
			MergeSort(array, left, right);
			CollectionAssert.AreEqual(array, expectedResult);
		}

		[TestMethod]
		public void MergeSort_SortingBigArray_SortedBigArray()
		{
			// Generate array of random integers
			Random r = new Random();
			int[] array = Enumerable.Range(-1000000, 1000000)
				.Select(_ => r.Next(0, 100))
				.ToArray(),
				expectedResult = new int[array.Length];

			// Get two equals array's objects
			Array.Copy(array, expectedResult, array.Length);

			// Sort the first with build-in method
			Array.Sort(expectedResult);

			// Sort the second with testing method
			MergeSort(array);

			CollectionAssert.AreEqual(array, expectedResult);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void MergeSort_NullArray_ArgumentNullException()
		{
			int[] array = null;
			MergeSort(array);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		[DataRow(new int[] { 1, 2, 3, }, -1, 1)]
		[DataRow(new int[] { 1, 2, 3, }, 0, -1)]
		[DataRow(new int[] { 1, 2, 3, }, -1, -1)]
		[DataRow(new int[] { 1, 2, 3, }, -1, 10)]
		[DataRow(new int[] { 1, 2, 3, }, 0, 10)]
		public void MergeSort_InvalidBordersValuesPassed_ArgumentOutOfRangeException(int[] array, int left, int right)
		{
			MergeSort(array, left, right);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void MergeSort_LeftBorderLargerThanRight_ArgumentException()
		{
			MergeSort(new int[] { 1, 2, 3 }, 1, 0);
		}
	}
}
