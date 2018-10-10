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
		public void QuickSortTest_ValidData_ValidResult()
		{
			// Generate array of random integers
			Random r = new Random();
			int[] array = Enumerable.Range(0, 100)
				.Select(_ => r.Next(0, 100))
				.ToArray(),
				expected = new int[array.Length];

			// Get two equals array's objects
			Array.Copy(array, expected, array.Length);

			// Sort the first with build-in method
			Array.Sort(expected);

			// Sort the second with testing method
			QuickSort(array);

			CollectionAssert.AreEqual(array, expected);
		}

		[TestMethod]
		public void MergeSortTest_ValidData_ValidResult()
		{
			// Generate array of random integers
			Random r = new Random();
			int[] array = Enumerable.Range(0, 100)
				.Select(_ => r.Next(0, 100))
				.ToArray(),
				expected = new int[array.Length];

			// Get two equals array's objects
			Array.Copy(array, expected, array.Length);

			// Sort the first with build-in method
			Array.Sort(expected);

			// Sort the second with testing method
			MergeSort(array);

			CollectionAssert.AreEqual(array, expected);
		}
	}
}
