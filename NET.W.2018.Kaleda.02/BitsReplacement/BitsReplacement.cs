using System;

namespace BitsReplacement
{
	public static class BitsReplacement
	{
		/// <summary>
		/// Replaces bits in firstNumber from index i to j (from left to right) on the first bits from the secondNumber.
		/// </summary>
		/// <param name="firstNumber">The number to bits replacement.</param>
		/// <param name="secondNumber">The number whick bits will be inserted.</param>
		/// <param name="i">The start position to insert.</param>
		/// <param name="j">The end position to isert.</param>
		/// <returns></returns>
		public static int InsertBits(int firstNumber, int secondNumber, int i, int j)
		{
			CheckIndexes(i, j);

			// Number of bits to replace.
			int length = j - i + 1;

			// Cyclic shift to the right, so now number starts with bits to replace.
			firstNumber = ShiftRightSigned(firstNumber, i) | (firstNumber << (32 - i));

			// Reset all bits of the secondNumber except the first, the number of which is equal to the number of bits to replace.
			secondNumber = ShiftRightSigned(secondNumber << (32 - length), (32 - length));

			// Reset the first bits of the firstNumber, the number of which is equal to the number of bits to replace.
			firstNumber = ShiftRightSigned(firstNumber, length) << length;

			// Insert the bits of the secondNumber into the firstNumber
			firstNumber = firstNumber | secondNumber;

			// Back doing a cyclic shift to the left.
			firstNumber = (firstNumber << i) | ShiftRightSigned(firstNumber, 32 - i);

			return firstNumber;
		}

		/// <summary>
		/// Unsigned right shift.
		/// </summary>
		/// <remarks>
		/// There is no unsigned operator in C# (like >>> in Java). Unsigned right-shifting means that 
		/// shifting a value n places to the right causes the n high order bits to contain zero. 
		/// </remarks>
		/// <param name="r">Number to right shift.</param>
		/// <param name="s">Number of symbols.</param>
		/// <returns>The number shifted on s positions to right.</returns>
		private static int ShiftRightSigned(int r, int s)
		{
			return s == 0 ? r : (r >> s) & ~(-1 << (32 - s));
		}

		/// <summary>
		/// Checks if passed indexes are valid.
		/// </summary>
		/// <param name="i">Starting index.</param>
		/// <param name="j">Ending index.</param>
		private static void CheckIndexes(int i, int j)
		{
			if (i < 0 || j < 0)
				throw new ArgumentOutOfRangeException(i < 0 ? nameof(i) : nameof(j), "Indexes must be non negative numbers.");

			if (i > j)
				throw new ArgumentException("Starting index should not be greater than ending index.");

			int numberOfBitsInByte = 8;
			if (j > sizeof(int) * numberOfBitsInByte)
				throw new ArgumentOutOfRangeException(nameof(j), "Ending index must not be greater than length of Int32 bit representation.");
		}
	}
}
