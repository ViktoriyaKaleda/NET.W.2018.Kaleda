using System;
using NUnit.Framework;
using Fibonacci;
using System.Linq;

namespace Fibonacci.Tests
{
	[TestFixture]
	public class FibonacciTests
	{
		[Test]
		public void Generate_ValidData_ValidResult()
		{
			CollectionAssert.AreEqual(Fibonacci.Generate(1), new int[] { 1 });
			CollectionAssert.AreEqual(Fibonacci.Generate(5), new int[]{ 1, 1, 2, 3, 5 });
		}

		[Test]
		public void Generate_NonPositiveCount_ArgumentException()
			=> Assert.Throws<ArgumentException>(() => Fibonacci.Generate(0).ToArray());

		[Test]
		public void Generate_ToBigNumberOfElements_()
			=> Assert.Throws<OverflowException>(() => Fibonacci.Generate(1000000).ToArray());
	}
}
