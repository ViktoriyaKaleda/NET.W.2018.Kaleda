using System;

namespace Matrix
{
	/// <summary>
	/// Represents arguments of chenging matrix elemnt event. 
	/// </summary>
	public class MatrixEventArgs : EventArgs
	{
		/// <summary>
		/// The row index.
		/// </summary>
		public int Row { get; }

		/// <summary>
		/// The column index.
		/// </summary>
		public int Column { get; }

		public MatrixEventArgs(int row, int column)
		{
			Row = row;
			Column = column;
		}
	}
}
