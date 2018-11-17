using System;
using System.Collections.Generic;

namespace Matrix
{
	/// <summary>
	/// Realization of symmetric matrix (square matrix that is equal to its transpose).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SymmetricMatix<T> : SquareMatrixBase<T>
	{
		private readonly T[][] _matrixArray;
		private int _version;

		/// <summary>
		/// Initialize new matrix object with given size.
		/// </summary>
		/// <param name="size">The size of new matrix.</param>
		public SymmetricMatix(int size) : base(size)
		{
			_matrixArray = new T[size][];
			for (int i = 0; i < size; i++)
			{
				_matrixArray[i] = new T[i + 1];
			}
		}

		/// <summary>
		/// Initialize new matrix object from given array.
		/// </summary>
		/// <param name="size">The size of new matrix.</param>
		/// <param name="source">The source array of matrix elemets that containes only matrix lower triangle.</param>
		public SymmetricMatix(int size, T[][] source) : base(size)
		{
			if (size != source.Length)
				throw new ArgumentException("Size of source array and size of new matrix are not equal.");

			_matrixArray = new T[size][];
			for (int i = 0; i < size; i++)
			{
				_matrixArray[i] = new T[i + 1];
				for (int j = 0; j <= i; j++)
					_matrixArray[i][j] = source[i][j];
			}
		}

		/// <summary>
		/// Set matrix value by given indexes.
		/// </summary>
		/// <param name="row">The row indes.</param>
		/// <param name="column">The column index.</param>
		/// <param name="value">The value to set.</param>
		protected override void SetValue(int row, int column, T value)
		{
			if (row < column)
				Swap(ref row, ref column);

			_matrixArray[row][column] = value;

			_version++;
		}

		/// <summary>
		/// Get matrix value by given indexes.
		/// </summary>
		/// <param name="row">The row indes.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The matrix value in given cell.</returns>
		protected override T GetValue(int row, int column)
		{
			if (row < column)
				Swap(ref row, ref column);

			return _matrixArray[row][column];
		}

		/// <summary>
		/// Returns enumerator for current matrix.
		/// </summary>
		/// <returns>Returns enumerator for current matrix.</returns>
		protected override IEnumerator<T> GetMatrixEnumerator()
		{
			int matrixVersion = _version;

			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j <= i; j++ )
				{
					if (matrixVersion != _version)
						throw new InvalidOperationException("Matrix was changed.");

					yield return _matrixArray[i][j];
				}

				for (int j = i + 1; j < Size; j++)
				{
					if (matrixVersion != _version)
						throw new InvalidOperationException("Matrix was changed.");

					yield return _matrixArray[j][i];
				}
			}
		}

		/// <summary>
		/// Implementation of addition operation for symmetric matrix.
		/// </summary>
		/// <param name="matrix">The matrix for addition.</param>
		/// <returns>Result of addition.</returns>
		protected override SquareMatrixBase<T> Add(SquareMatrixBase<T> matrix)
		{
			if (this.Size != matrix.Size)
				throw new ArgumentException("Matrixes must have the same size.", nameof(matrix));

			SquareMatrixBase<T> result;

			if (matrix.GetType() == typeof(SymmetricMatix<T>))
				result = new SymmetricMatix<T>(Size);

			else
				result = new SquareMatrix<T>(Size);

			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
					result[i, j] = (dynamic)this[i, j] + (dynamic)matrix[i, j];
			}

			return result;
		}

		/// <summary>
		/// Swaps two integer values.
		/// </summary>
		/// <param name="a">First variable to swap.</param>
		/// <param name="b">Second variable to swap.</param>
		private static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}
	}
}
