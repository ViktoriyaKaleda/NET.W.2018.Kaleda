using NUnit.Framework;
using System;

namespace Sort.NUnitTests
{
	[TestFixture]
	public class SortTests
	{
		private static int[][] testArray =
		{
			new int[] { 100 },						// Max = 100, Min = 100,  Sum = 100
			new int[] { 1, 2, 3 },                  // Max = 3,   Min = 1,    Sum = 6
            new int[] { -1, 2, 10 },				// Max = 10,  Min = -1,   Sum = 11
            new int[] { 5, 6, 7, 8, 9 },            // Max = 9,   Min = 5,    Sum = 34
        };

		private static int[][] testArraySortedByAscendingSum =
		{
			new int[] { 1, 2, 3 },
			new int[] { -1, 2, 10 },
			new int[] { 5, 6, 7, 8, 9 },
			new int[] { 100 },
		};

		private static int[][] testArraySortedByDescendingSum =
		{
			new int[] { 100 },
			new int[] { 5, 6, 7, 8, 9 },			
			new int[] { -1, 2, 10 },
			new int[] { 1, 2, 3 },
		};

		private static int[][] testArraySortedByAscendingMax =
		{
			new int[] { 1, 2, 3 },
			new int[] { 5, 6, 7, 8, 9 },
			new int[] { -1, 2, 10 },
			new int[] { 100 },
		};

		private static int[][] testArraySortedByDescendingMax =
		{
			new int[] { 100 },
			new int[] { -1, 2, 10 },
			new int[] { 5, 6, 7, 8, 9 },
			new int[] { 1, 2, 3 },
		};

		private static int[][] testArraySortedByAscendingMin =
		{
			new int[] { -1, 2, 10 },
			new int[] { 1, 2, 3 },
			new int[] { 5, 6, 7, 8, 9 },
			new int[] { 100 },
		};

		private static int[][] testArraySortedByDescendingMin =
		{
			new int[] { 100 },
			new int[] { 5, 6, 7, 8, 9 },
			new int[] { 1, 2, 3 },
			new int[] { -1, 2, 10 },
		};

		[Test]
		public void Sort_NullParameters_ArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => BubleSort.BubbleSort.Sort(null, new Comparers.ByAscendingMaxElements()));
			Assert.Throws<ArgumentNullException>(() => BubleSort.BubbleSort.Sort(testArray, null));
		}

		[Test]
		public void Sort_SortByAscendingSum_ValidResult()
		{
			var comparer = new Comparers.ByAscendingRowElementsSums();
			var result = GetCopy(testArray);

			BubleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByAscendingSum, result);
		}

		[Test]
		public void Sort_SortByDescendingSum_ValidResult()
		{
			var comparer = new Comparers.ByDescendingRowElementsSums();
			var result = GetCopy(testArray);

			BubleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByDescendingSum, result);
		}

		[Test]
		public void Sort_SortByAscendingMax_ValidResult()
		{
			var comparer = new Comparers.ByAscendingMaxElements();
			var result = GetCopy(testArray);

			BubleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByAscendingMax, result);
		}

		[Test]
		public void Sort_SortByDescendingMax_ValidResult()
		{
			var comparer = new Comparers.ByDescendingMaxElements();
			var result = GetCopy(testArray);

			BubleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByDescendingMax, result);
		}

		[Test]
		public void Sort_SortByAscendingMin_ValidResult()
		{
			var comparer = new Comparers.ByAscendingMinElements();
			var result = GetCopy(testArray);

			BubleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByAscendingMin, result);
		}
		[Test]
		public void Sort_SortByDescendingMin_ValidResult()
		{
			var comparer = new Comparers.ByDescendingMinElements();
			var result = GetCopy(testArray);

			BubleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByDescendingMin, result);
		}

		private int[][] GetCopy(int[][] array)
		{
			int[][] copy = new int[array.Length][];
			for (int i = 0; i < array.Length; i++)
			{
				copy[i] = new int[array[i].Length];
				for (int j = 0; j < copy[i].Length; j++)
					copy[i][j] = array[i][j];
			}
			return copy;
		}
	}
}
