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
		[TestCase(0, new int[] { 0, 2, 201, 200, 21, -70, -15, 17 }, new int[] { 0, 201, 200, -70 })]
		[TestCase(2, new int[] { 0, 2, -201, 200, -21, 70, -15, 17 }, new int[] { 2, -201, 200, -21})]
		[TestCase(1, new int[] { 0 }, new int[] { })]
		[TestCase(1, new int[] {  }, new int[] { })]
		public void FilterDigit_ValidDigitAndArrayOfNumbersToSort_FilteredList(int digit, int[] list, IEnumerable<int> expectedResult)
		{
			var result = Filter.Filter.FilterDigit(digit, list);
			CollectionAssert.AreEqual(result, expectedResult);
		}
		
		[Test]
		public void FilterDigit_NullArray_ArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => Filter.Filter.FilterDigit(0, null));
		}

		[Test]
		public void FilterDigit_NegativeDigitParameter_ArgumentException()
		{
			Assert.Throws<ArgumentException>(() => Filter.Filter.FilterDigit(-1, null));
		}

		[Test]
		public void FilterDigit_GreaterThan9DigitParameter_ArgumentException()
		{
			Assert.Throws<ArgumentException>(() => Filter.Filter.FilterDigit(10, null));
		}
	}
}
