using System;
using System.Collections.Generic;

namespace Matrix
{
	/// <summary>
	/// Realization of square matrix (matrix which number of rows and columns are equal).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SquareMatrix<T> : SquareMatrixBase<T>
	{
		private readonly T[] _matrixArray;
		private int _version;

		/// <summary>
		/// Initialize new matrix object with given size.
		/// </summary>
		/// <param name="size">The size of new matrix.</param>
		public SquareMatrix(int size) : base(size)
		{
			_matrixArray = new T[size * size];
		}

		/// <summary>
		/// Initialize new matrix object from given array.
		/// </summary>
		/// <param name="size">The size of new matrix.</param>
		/// <param name="source">The source array of matrix elemets.</param>
		public SquareMatrix(int size, T[] source) : base(size)
		{
			if (size * size != source.Length)
				throw new ArgumentException("Size of source array and size of new matrix are not equal.");

			_matrixArray = new T[size * size];

			for (int i = 0; i < _matrixArray.Length; i++)
				_matrixArray[i] = source[i];
		}

		/// <summary>
		/// Set matrix value by given indexes.
		/// </summary>
		/// <param name="row">The row indes.</param>
		/// <param name="column">The column index.</param>
		/// <param name="value">The value to set.</param>
		protected override void SetValue(int row, int column, T value)
		{
			_matrixArray[(row * Size) + column] = value;
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
			return _matrixArray[(row * Size) + column];
		}

		/// <summary>
		/// Returns enumerator for current matrix.
		/// </summary>
		/// <returns>Returns enumerator for current matrix.</returns>
		protected override IEnumerator<T> GetMatrixEnumerator()
		{
			int matrixVersion = _version;

			foreach (T value in _matrixArray)
			{
				if (matrixVersion != _version)
					throw new InvalidOperationException("Matrix was changed.");

				yield return value;
			}
		}

		/// <summary>
		/// Implementation of addition operation for square matrix.
		/// </summary>
		/// <param name="matrix">The matrix for addition.</param>
		/// <returns>Result of addition.</returns>
		protected override SquareMatrixBase<T> Add(SquareMatrixBase<T> matrix)
		{
			if (this.Size != matrix.Size)
				throw new ArgumentException("Matrices must have the same size.", nameof(matrix));

			var result = new SquareMatrix<T>(Size);

			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
					result[i, j] = (dynamic)this[i, j] + (dynamic)matrix[i, j];
			}

			return result;
		}
	}
}
