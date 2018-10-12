using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitsReplacementMSTests
{
	[TestClass]
	public class BitsReplacementTests
	{
		[TestMethod]
		[DataRow(15, 15, 0, 0, 15)]
		[DataRow(8, 15, 0, 0, 9)]
		[DataRow(8, 15, 3, 8, 120)]
		[DataRow(123, 75, 2, 5, 111)]
		[DataRow(-123, 10, 5, 8, -187)]
		public void InsertBits_ValidCases_NumberWithReplacedBits(int firstNumber, int secondNumber, int i, int j, int expectedResult)
		{
			int result = BitsReplacement.BitsReplacement.InsertBits(firstNumber, secondNumber, i, j);

			Assert.AreEqual(result, expectedResult);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		[DataRow(1, 1, -1, 0)]
		[DataRow(1, 1, 0, -1)]
		[DataRow(1, 1, -1, -1)]
		[DataRow(1, 1, 5, 4)]
		[DataRow(1, 1, 0, 40)]
		public void InsertBits_InvalidIndexes_ArgumentOutOfRangeException(int firstNumber, int secondNumber, int i, int j)
		{
			BitsReplacement.BitsReplacement.InsertBits(firstNumber, secondNumber, i, j);
		}
	}
}
