using System;
using NUnit.Framework;

namespace NextBiggerNumberNUnitTests
{
	[TestFixture]
	public class NextBiggerNumberTests
	{
		[Test]
		[TestCase(12, 21)]
		[TestCase(513, 531)]
		[TestCase(2017, 2071)]
		[TestCase(414, 441)]
		[TestCase(144, 414)]
		[TestCase(1234321, 1241233)]
		[TestCase(1234126, 1234162)]
		[TestCase(3456432, 3462345)]
		[TestCase(10, -1)]
		[TestCase(20, -1)]
		public void FindNextBiggerNumber(int number, int expectedResult)
		{
			int result = NextBiggerNumber.NextBiggerNumber.FindNextBiggerNumber(number);
			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}
}
