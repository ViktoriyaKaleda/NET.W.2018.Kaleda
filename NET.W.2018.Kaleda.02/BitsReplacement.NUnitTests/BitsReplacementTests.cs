using NUnit.Framework;
using System;

namespace BitsReplacement.NUnitTests
{
	[TestFixture]
	public class BitsReplacementTests
	{
		[Test]
		[TestCase(15, 15, 0, 0, 15)]
		[TestCase(8, 15, 0, 0, 9)]
		[TestCase(8, 15, 3, 8, 120)]
		[TestCase(123, 75, 2, 5, 111)]
		[TestCase(-123, 10, 5, 8, -187)]
		public void InsertBits_ValidCases_NumberWithReplacedBits(int firstNumber, int secondNumber, int i, int j, int expectedResult)
		{
			int result = BitsReplacement.InsertBits(firstNumber, secondNumber, i, j);

			Assert.AreEqual(result, expectedResult);
		}

		[Test]
		[TestCase(1, 1, -1, 0)]
		[TestCase(1, 1, 0, -1)]
		[TestCase(1, 1, -1, -1)]
		[TestCase(1, 1, 0, 32)]
		public void InsertBits_InvalidIndexes_ArgumentOutOfRangeException(int firstNumber, int secondNumber, int i, int j)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => BitsReplacement.InsertBits(firstNumber, secondNumber, i, j));			
		}

		[Test]
		public void InsertBits_EndingIndexIsGreaterThanStartingIndex_ArgumentException()
		{
			Assert.Throws<ArgumentException>(() => BitsReplacement.InsertBits(1, 1, 2, 1));
		}
	}
}
