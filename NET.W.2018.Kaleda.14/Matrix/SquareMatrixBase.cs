using System;
using System.Collections;
using System.Collections.Generic;

namespace Matrix
{
	/// <summary>
	/// Base class for square matrix.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class SquareMatrixBase<T> : IEnumerable<T>
    {
		/// <summary>
		/// Event that invokes when matrix element is changed.
		/// </summary>
		public event EventHandler ElementChanged;
		
		public int Size { get; }
		
		/// <summary>
		/// Initialize new matrix object.
		/// </summary>
		/// <param name="size">The size of the matrix.</param>
		public SquareMatrixBase(int size)
		{
			if (size < 0)
				throw new ArgumentException("Non negative value required.", nameof(size));

			Size = size;
		}
		
		/// <summary>
		/// Indexer for matrix.
		/// </summary>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The value of given matrix cell.</returns>
		public virtual T this[int row, int column]
		{
			get
			{
				CheckIndexes(row, column);
				return GetValue(row, column);
			}
			set
			{
				CheckIndexes(row, column);
				SetValue(row, column, value);
				ElementChanged?.Invoke(this, new MatrixEventArgs(row, column));
			}
		}

		/// <summary>
		/// Sum up two matrix.
		/// </summary>
		/// <param name="lhs">The first matrix for addition.</param>
		/// <param name="rhs">The second matrix for addition.</param>
		/// <returns>Reault of addition.</returns>
		public static SquareMatrixBase<T> operator +(SquareMatrixBase<T> lhs, SquareMatrixBase<T> rhs)
		{
			return lhs.Add(rhs);
		}

		/// <summary>
		/// Returns enumerator for current matrix.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return GetMatrixEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		protected abstract void SetValue(int row, int column, T value);
		protected abstract T GetValue(int row, int column);
		protected abstract IEnumerator<T> GetMatrixEnumerator();
		protected abstract SquareMatrixBase<T> Add(SquareMatrixBase<T> matrix);
		
		/// <summary>
		/// Checks given matrix indexes.
		/// </summary>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		private void CheckIndexes(int row, int column)
		{
			if (row < 0 || column < 0)
				throw new ArgumentOutOfRangeException(row < 0 ? nameof(row) : nameof(column), 
					"Non negative number required.");

			if (row >= Size || column >= Size)
				throw new ArgumentOutOfRangeException(row >= Size ? nameof(row) : nameof(column),
					"Value must be smaller than matrix size.");
		}
	}
}
