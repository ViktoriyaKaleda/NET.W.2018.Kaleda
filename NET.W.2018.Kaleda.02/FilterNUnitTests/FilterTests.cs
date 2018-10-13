using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FilterNUnitTests
{
	[TestFixture]
	public class FilterTests
	{
		[Test]
		[TestCase(7, new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}, new int[] {7, 70, 17})]
		[TestCase(0, new int[] { 0, 2, 201, 200, 21, 70, 15, 17 }, new int[] { 0, 201, 200, 70 })]
		[TestCase(1, new int[] { 0 }, new int[] { })]
		[TestCase(1, new int[] {  }, new int[] { })]
		public void FilterDigit_ValidDigitAndArrayOfNumbersToSort_FilteredList(int digit, int[] list, IEnumerable<int> expectedResult)
		{
			var result = Filter.Filter.FilterDigit(digit, list);
			CollectionAssert.AreEqual(result, expectedResult);
		}
	}
}
