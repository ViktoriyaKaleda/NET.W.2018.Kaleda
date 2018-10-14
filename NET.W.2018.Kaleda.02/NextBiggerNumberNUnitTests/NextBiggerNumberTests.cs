using System;
using NUnit.Framework;

namespace NextBiggerNumberNUnitTests
{
	[TestFixture]
	public class NextBiggerNumberTests
	{
		[Test, TestCaseSource("NumbersCases")]
		public void FindNextBiggerNumber_FindingResult_NextBiggerNumber(int number, int expectedResult)
		{
			int result = NextBiggerNumber.NextBiggerNumber.FindNextBiggerNumber(number);
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test, TestCaseSource("NumbersCases")]
		public void FindNextBiggerNumberWithExecutionTime_FindingResultWithOutExecutionTime_NextBiggerNumber(int number, int expectedResult)
		{
			TimeSpan executionTime;
			int result = NextBiggerNumber.NextBiggerNumber.FindNextBiggerNumberWithExecutionTime(number, out executionTime);
			Assert.That(result, Is.EqualTo(expectedResult));
			Assert.That(executionTime.TotalSeconds, Is.Positive);
		}

		[Test, TestCaseSource("NumbersCases")]
		public void FindNextBiggerNumberWithExecutionTime_FindingResultInTuple_NextBiggerNumber(int number, int expectedResult)
		{
			TimeSpan executionTime;
			int result;
			(result, executionTime) = NextBiggerNumber.NextBiggerNumber.FindNextBiggerNumberWithExecutionTime(number);
			Assert.That(result, Is.EqualTo(expectedResult));
			Assert.That(executionTime.TotalSeconds, Is.Positive);
		}

		public static object[] NumbersCases =
		{
			new int[] { 12, 21 },
			new int[] { 2017, 2071 },
			new int[] { 513, 531 },
			new int[] { 414, 441 },
			new int[] { 144, 414 },
			new int[] { 1234321, 1241233 },
			new int[] { 1234126, 1234162 },
			new int[] { 3456432, 3462345 },
			new int[] { 10, -1 },
			new int[] { 22, -1 }
		};
	}
}
