using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearch.Tests
{
	[TestFixture]
	public class BinarySearchHelperTests
	{
		public static int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		public static string[] stringArray = { "abc", "bcd", "e", "fFfF" };
		public static int[] nullIntArray = null;

		[Test]
		public void Search_SearchingIntUsingDefaultComparer_ValidResult()
		{
			Assert.That(intArray.BinarySearch(3), Is.EqualTo(2));
			Assert.That(intArray.BinarySearch(3, null), Is.EqualTo(2));
		}

		[Test]
		public void Search_SearchingIntOnIntervalUsingDefaultComparer_ValidResult()
		{
			Assert.That(intArray.BinarySearch(1, 3, 3, null), Is.EqualTo(2));
		}

		[Test]
		public void Search_SearchingIntOnSingleIntervalUsingDefaultComparer_ValidResult()
		{
			Assert.That(intArray.BinarySearch(2, 2, 3, null), Is.EqualTo(2));
		}

		[Test]
		public void Search_SearchingNotExistingInt_NegativeNumber()
		{
			Assert.That(intArray.BinarySearch(11), Is.LessThan(0));
			Assert.That(intArray.BinarySearch(11, null), Is.LessThan(0));
		}

		[Test]
		public void Search_SearchingStringUsingDefaultComparer_ValidResult()
		{
			Assert.That(stringArray.BinarySearch("abc"), Is.EqualTo(0));
			Assert.That(stringArray.BinarySearch("abc", null), Is.EqualTo(0));
		}

		[Test]
		public void Search_SearchingStringUsingCustomComparer_ValidResult()
		{
			Assert.That(stringArray.BinarySearch("ffff", new CustomStringComparer()), Is.EqualTo(3));
		}

		[Test]
		public void Search_NullArray_ArgumentNullException()
			=> Assert.Throws<ArgumentNullException>(() => nullIntArray.BinarySearch(1));

		[Test]
		public void Search_NegativeIndexOrCount_ArgumentOutOfRangeException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => intArray.BinarySearch(-1, 1, 1, null));
			Assert.Throws<ArgumentOutOfRangeException>(() => intArray.BinarySearch(1, -1, 1, null));
		}

		[Test]
		public void Search_InvalidInterval_ArgumentException()
			=> Assert.Throws<ArgumentException>(() => intArray.BinarySearch(10, 1, 1, null));

		private class CustomStringComparer : IComparer<string>
		{
			public int Compare(string x, string y)
			{
				x = x.ToUpper();
				y = y.ToUpper();
				return x.CompareTo(y);
			}
		}
	}
}
