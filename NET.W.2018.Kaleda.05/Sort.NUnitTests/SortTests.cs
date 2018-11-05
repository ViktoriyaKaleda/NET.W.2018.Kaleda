using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sort.NUnitTests
{
	[TestFixture]
	public class SortTests
	{
		#region Tests data
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
		#endregion

		[Test]
		public void Sort_NullParameters_ArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => BubbleSort.BubbleSort.Sort(null, new Comparers.ByAscendingMaxElements()));
			Assert.Throws<ArgumentNullException>(() => BubbleSort.BubbleSort.Sort(testArray, (IComparer<int[]>)null));
			Assert.Throws<ArgumentNullException>(() => BubbleSort.BubbleSort.Sort(testArray, (Comparison<int[]>)null));
		}

		[Test]
		public void SortByInterface_SortByAscendingSum_ValidResult()
		{
			var comparer = new Comparers.ByAscendingRowElementsSums();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByAscendingSum, result);
		}

		#region Tests for from interface method

		[Test]
		public void SortByInterface_SortByDescendingSum_ValidResult()
		{
			var comparer = new Comparers.ByDescendingRowElementsSums();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByDescendingSum, result);
		}

		[Test]
		public void SortByInterface_SortByAscendingMax_ValidResult()
		{
			var comparer = new Comparers.ByAscendingMaxElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByAscendingMax, result);
		}

		[Test]
		public void SortByInterface_SortByDescendingMax_ValidResult()
		{
			var comparer = new Comparers.ByDescendingMaxElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByDescendingMax, result);
		}

		[Test]
		public void SortByInterface_SortByAscendingMin_ValidResult()
		{
			var comparer = new Comparers.ByAscendingMinElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByAscendingMin, result);
		}
		[Test]
		public void SortByInterface_SortByDescendingMin_ValidResult()
		{
			var comparer = new Comparers.ByDescendingMinElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer);

			CollectionAssert.AreEqual(testArraySortedByDescendingMin, result);
		}

		#endregion

		#region Tests for from delegate method

		[Test]
		public void SortByDelegate_SortByAscendingSum_ValidResult()
		{
			var comparer = new Comparers.ByAscendingRowElementsSums();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer.Compare);

			CollectionAssert.AreEqual(testArraySortedByAscendingSum, result);
		}

		[Test]
		public void SortByDelegate_SortByDescendingSum_ValidResult()
		{
			var comparer = new Comparers.ByDescendingRowElementsSums();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer.Compare);

			CollectionAssert.AreEqual(testArraySortedByDescendingSum, result);
		}

		[Test]
		public void SortByDelegate_SortByAscendingMax_ValidResult()
		{
			var comparer = new Comparers.ByAscendingMaxElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer.Compare);

			CollectionAssert.AreEqual(testArraySortedByAscendingMax, result);
		}

		[Test]
		public void SortByDelegate_SortByDescendingMax_ValidResult()
		{
			var comparer = new Comparers.ByDescendingMaxElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer.Compare);

			CollectionAssert.AreEqual(testArraySortedByDescendingMax, result);
		}

		[Test]
		public void SortByDelegate_SortByAscendingMin_ValidResult()
		{
			var comparer = new Comparers.ByAscendingMinElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer.Compare);

			CollectionAssert.AreEqual(testArraySortedByAscendingMin, result);
		}
		[Test]
		public void SortByDelegate_SortByDescendingMin_ValidResult()
		{
			var comparer = new Comparers.ByDescendingMinElements();
			var result = GetCopy(testArray);

			BubbleSort.BubbleSort.Sort(result, comparer.Compare);

			CollectionAssert.AreEqual(testArraySortedByDescendingMin, result);
		}

		#endregion

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
