using System;
using System.Collections.Generic;

namespace Matrix
{
	/// <summary>
	/// Realization of diagonal matrix (square matrix that contains elements only on it diagonal).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DiagonalMatix<T> : SquareMatrixBase<T>
	{		
		private readonly T[] _matrixArray;
		private int _version;
		
		/// <summary>
		/// Initialize new matrix object with given size.
		/// </summary>
		/// <param name="size">The size of new matrix.</param>
		public DiagonalMatix(int size) : base(size) 
			=> _matrixArray = new T[size];

		/// <summary>
		/// Initialize new matrix object from given array.
		/// </summary>
		/// <param name="size">The size of new matrix.</param>
		/// <param name="source">The source array of matrix diagonal elemets.</param>
		public DiagonalMatix(int size, T[] source) : base(size)
		{
			if (size != source.Length)
				throw new ArgumentException("Size of source array and size of new matrix are not equal.");

			_matrixArray = new T[size];

			for (int i = 0; i < Size; i++)
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
			if (row != column)
				throw new ArgumentException("Invalid indexes for diagonal matrix.");

			_matrixArray[row] = value;
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
			if (row != column)
				return default(T);

			return _matrixArray[row];
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
				for (int j = 0; j < Size; j++)
				{
					if (matrixVersion != _version)
						throw new InvalidOperationException("Matrix was changed.");

					if (i != j)
						yield return default(T);

					else
						yield return _matrixArray[i];
				}
			}
		}

		/// <summary>
		/// Implementation of addition operation for diagonal matrix.
		/// </summary>
		/// <param name="matrix">The matrix for addition.</param>
		/// <returns>Result of addition.</returns>
		protected override SquareMatrixBase<T> Add(SquareMatrixBase<T> matrix)
		{
			if (this.Size != matrix.Size)
				throw new ArgumentException("Matrixes must have the same size.", nameof(matrix));

			SquareMatrixBase<T> result;

			if (matrix.GetType() == typeof(DiagonalMatix<T>))
			{
				result = new DiagonalMatix<T>(Size);
				for (int i = 0; i < Size; i++)
					result[i, i] = (dynamic)this[i, i] + (dynamic)matrix[i, i];

				return result;
			}

			else
				result = new SquareMatrix<T>(Size);

			for(int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
					result[i, j] = (dynamic)this[i, j] + (dynamic)matrix[i, j];
			}

			return result;
		}
	}
}
