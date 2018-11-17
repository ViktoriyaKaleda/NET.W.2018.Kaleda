using System;
using NUnit.Framework;
using Matrix;

namespace Matrix.Tests
{
	class SymmetricMatrixTests
	{
		public static int[][] source = new int[][]{ new int[]{ 1 }, new int[]{ 2, 3 }, new int[] { 4, 5, 6 } };
		public static int[] matrixItems = { 1, 2, 4, 2, 3, 5, 4, 5, 6 };

		[Test]
		public void Indexer_ValidValues_ValidResult()
		{
			var matrix = new SymmetricMatix<int>(3, source);

			int k = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
					Assert.That(matrix[i, j], Is.EqualTo(matrixItems[k++]));
			}
		}

		[Test]
		public void Iteration_ValidValues_ValidResult()
		{
			var matrix = new SymmetricMatix<int>(3, source);

			int i = 0;
			foreach (var item in matrix)
			{
				Assert.That(item, Is.EqualTo(matrixItems[i++]));
			}
		}

		[Test]
		public void AdditionOperator_TwoSymmetricMatrices_ValidResult()
		{
			var matrix1 = new SymmetricMatix<int>(3, source);
			var matrix2 = new SymmetricMatix<int>(3, source);

			var result = matrix1 + matrix2;
			var expectedResult = new int[] { 2, 4, 8, 4, 6, 10, 8, 10, 12 };

			int i = 0;
			foreach (var item in result)
			{
				Assert.That(item, Is.EqualTo(expectedResult[i++]));
			}

			Assert.That(result.GetType(), Is.EqualTo(typeof(SymmetricMatix<int>)));
		}

		[Test]
		public void AdditionOperator_SymmetricAndSquareMatrices_ValidResult()
		{
			var matrix1 = new SymmetricMatix<int>(3, source);
			var matrix2 = new SquareMatrix<int>(3, matrixItems);

			var result = matrix1 + matrix2;
			var expectedResult = new int[] { 2, 4, 8, 4, 6, 10, 8, 10, 12 };

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
			Assert.Throws<ArgumentException>(() => new SymmetricMatix<int>(-1));
			Assert.Throws<ArgumentException>(() => new SymmetricMatix<int>(2, source));
			Assert.Throws<ArgumentException>(() => new SymmetricMatix<int>(4, source));
		}

		[Test]
		public void Iteration_ChengingMatrix_InvalidOperationException()
		{
			var matrix = new SymmetricMatix<int>(3, source);

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
