using NUnit.Framework;
using System;

namespace NthRootNUnitTests
{
	[TestFixture]
	public class NthRootTests
	{
		[Test]
		[TestCase(1, 5, 0.0001, 1)]
		[TestCase(8, 3, 0.0001, 2)]
		[TestCase(0.001, 3, 0.0001, 0.1)]
		[TestCase(0.04100625, 4, 0.0001, 0.45)]
		[TestCase(8, 3, 0.0001, 2)]
		[TestCase(0.0279936, 7, 0.0001, 0.6)]
		[TestCase(0.0081, 4, 0.1, 0.3)]
		[TestCase(-0.008, 3, 0.1, -0.2)]
		[TestCase(0.004241979, 9, 0.00000001, 0.545)]
		public void FindNthRoot_ValidParametrs_NthRootOfNumber(double number, int n, double accuracy, double expectedResult)
		{
			double result = NthRoot.NthRoot.FindNthRoot(number, n, accuracy);
			Assert.That(result, Is.InRange(expectedResult - accuracy, expectedResult + accuracy));
		}

		[Test]
		[TestCase(1, 0, 0.0001)]
		[TestCase(1, -1, 0.0001)]
		[TestCase(1, 2, -1)]
		public void FindNthRoot_InvalidDegreeOrAccuracy_ArgumentOutOfRangeException(double number, int n, double accuracy)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => NthRoot.NthRoot.FindNthRoot(number, n, accuracy));
		}
	}
}
