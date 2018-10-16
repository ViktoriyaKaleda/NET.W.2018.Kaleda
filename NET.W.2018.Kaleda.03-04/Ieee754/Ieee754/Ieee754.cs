using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Ieee754
{
	public static class Ieee754
    {
		/// <summary>
		/// Returns the IEEE 754 representation of double number.
		/// </summary>
		/// <param name="number">Number to convert.</param>
		/// <returns>String that contains the IEEE 754 representation of double number.</returns>
		public static string GetIeee754Representation(this double number)
		{
			return ConvertLongToBinaryString(new Union(number).longNumber);
		}

		/// <summary>
		/// Converts long number to binary.
		/// </summary>
		/// <param name="value">Number to convert.</param>
		/// <returns>String that contains binary representation of the number.</returns>
		private static string ConvertLongToBinaryString(long value)
		{
			const int doubleSize = 64;
			var result = new char[doubleSize];

			for (int i = 0; i < doubleSize; i++)
			{
				long mask = 1L << i;
				result[doubleSize - i - 1] = (value & mask) == 0 ? '0' : '1';
			}
			
			return new string(result);
		}

		/// <summary>
		/// Structure all fields of which start at the same location in memory.
		/// So longNumber field will contain doubleNumber IEEE 754 representation.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct Union
		{
			[FieldOffset(0)]
			private readonly double doubleNumber;

			[FieldOffset(0)]
			public readonly long longNumber;

			public Union(double number)
			{
				longNumber = 0;
				doubleNumber = number;				
			}
		}
    }
}
