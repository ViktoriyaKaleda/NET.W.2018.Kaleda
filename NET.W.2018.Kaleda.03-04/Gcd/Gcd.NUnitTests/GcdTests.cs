using NUnit.Framework;
using System;

namespace Gcd.NUnitTests
{
	[TestFixture]
	public class GcdTests
	{
		[TestCaseSource("ParametersCases")]
		public void GetGcd_ValidData_GcdOfTwoNumbers(int expectedResult, params int[] data)
		{
			(int result, TimeSpan executionTime) = Gcd.GetGcd(data);
			Assert.That(result, Is.EqualTo(expectedResult));
			Assert.That(executionTime.TotalMilliseconds, Is.InRange(0, 10));
		}

		[TestCaseSource("ParametersCases")]
		public void GetGcdBinary_ValidData_GcdOfTwoNumbers(int expectedResult, params int[] data)
		{
			(int result, TimeSpan executionTime) = Gcd.GetGcdBinary(data);
			Assert.That(result, Is.EqualTo(expectedResult));
			Assert.That(executionTime.TotalMilliseconds, Is.InRange(0, 10));
		}

		public static object[] ParametersCases =
		{
			new object[] { 1, new int[] { 1, 10 } },
			new object[] { 5, new int[] {5, 10 } },
			new object[] { 24, new int[] { 24, 24, } },
			new object[] { 0, new int[] {0, 0 } },
			new object[] { 5, new int[] {5, 0 } },
			new object[] { 15, new int[] { 0, 15 } },
			new object[] { 5, new int[] {-5, 10 } },
			new object[] { 5, new int[] {-10, 5 } },
			new object[] { 1, new int[] { int.MaxValue, 5 } },
			new object[] { 400, new int[] { 2147483600, 1200 } },
			new object[] { 20, new int[] {100, 20, 60 } },
			new object[] { 10000, new int[] { 0, 0, 10000, 0 } }
	};
	}
}
