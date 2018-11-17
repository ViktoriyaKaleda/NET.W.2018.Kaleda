using System;
using NUnit.Framework;
using Matrix;

namespace Matrix.Tests
{
	[TestFixture]
	public class SquareMatrixTests
	{
		public static int[] source = { 1, 2, 3, 4 };

		[Test]
		public void Indexer_ValidValues_ValidResult()
		{
			var matrix = new SquareMatrix<int>(2, source);

			Assert.That(matrix[0, 0], Is.EqualTo(1));
			Assert.That(matrix[0, 1], Is.EqualTo(2));
			Assert.That(matrix[1, 0], Is.EqualTo(3));
			Assert.That(matrix[1, 1], Is.EqualTo(4));
		}

		[Test]
		public void Iteration_ValidValues_ValidResult()
		{
			var matrix = new SquareMatrix<int>(2, source);
			int i = 0;
			foreach (var item in matrix)
			{
				Assert.That(item, Is.EqualTo(source[i++]));
			}
		}

		[Test]
		public void AdditionOperator_ValidValues_ValidResult()
		{
			var matrix1 = new SquareMatrix<int>(2, source);
			var matrix2 = new SquareMatrix<int>(2, source);

			var result = matrix1 + matrix2;
			var expectedResult = new int[]{ 2, 4, 6, 8};

			int i = 0;
			foreach (var item in result)
			{
				Assert.That(item, Is.EqualTo(expectedResult[i++]));
			}

			Assert.That(result.GetType(), Is.EqualTo(typeof(SquareMatrix<int>)));
		}

		[Test]
		public void Constructor_InvalidSize_ArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(-1));
			Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(1, source));
			Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(3, source));
		}

		[Test]
		public void Indexer_InvalidIndexes_ArgumentOutOfRangeException()
		{
			var matrix = new SquareMatrix<int>(2, source);

			Assert.Throws<ArgumentOutOfRangeException>(() => matrix[-1, 0]++);
			Assert.Throws<ArgumentOutOfRangeException>(() => matrix[0, -1]++);
			Assert.Throws<ArgumentOutOfRangeException>(() => matrix[2, 0]++);
			Assert.Throws<ArgumentOutOfRangeException>(() => matrix[0, 2]++);
		}

		[Test]
		public void Iteration_ChengingMatrix_InvalidOperationException()
		{
			var matrix = new SquareMatrix<int>(2, source);

			Assert.Throws<InvalidOperationException>(() =>
			{
				foreach (var item in matrix)
				{
					matrix[0, 0] = 1;
				}
			});
		}
	}
}
