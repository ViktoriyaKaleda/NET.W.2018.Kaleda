using System;

namespace Gcd
{
	public static class Gcd
	{
		/// <summary>
		/// Returns the GCD of passed numbers calculated by Euclidean algorithm and execution time.
		/// </summary>
		/// <param name="numbers">Numbers for GCD.</param>
		/// <exception cref="ArgumentException">
		/// Throw when less than 2 numbers passed.
		/// </exception>
		/// <returns>Returns the GCD of passed numbers and execution time.</returns>
		public static (int result, TimeSpan executionTime) GetGcd(params int[] numbers)
		{
			return GetNumbersGcd(GetGcdOfTwoNumbers, numbers);
		}

		/// <summary>
		/// Returns the GCD of passed numbers calculated by binary algorithm and execution time.
		/// </summary>
		/// <param name="numbers">Numbers for GCD.</param>
		/// <exception cref="ArgumentException">
		/// Throw when less than 2 numbers passed.
		/// </exception>
		/// <returns>Returns the GCD of passed numbers and execution time.</returns>
		public static (int result, TimeSpan executionTime) GetGcdBinary(params int[] numbers)
		{
			return GetNumbersGcd(GetGcdOfTwoNumbersBinary, numbers);
		}

		/// <summary>
		/// Returns the GCD of passed numbers and execution time.
		/// </summary>
		/// <param name="func">Function that implements GCD algorithm.</param>
		/// <param name="numbers">Numbers for GCD.</param>
		/// <exception cref="ArgumentException">
		/// Throw when less than 2 numbers passed.
		/// </exception>
		/// <returns>Returns the GCD of passed numbers and execution time.</returns>
		private static (int result, TimeSpan executionTime) GetNumbersGcd(Func<int, int, int> func, params int[] numbers)
		{
			var timer = System.Diagnostics.Stopwatch.StartNew();

			int n = numbers.Length;

			if (n < 2)
				throw new ArgumentException("At least 2 values expected.", nameof(numbers));

			int result = numbers[0];

			for (int i = 1; i < n; i++)
			{
				result = func(result, numbers[i]);
			}

			timer.Stop();

			return (result, timer.Elapsed);
		}

		/// <summary>
		/// Realization of finding GCD of two numbers by Euclidean algorithm.
		/// </summary>
		/// <param name="a">The first number.</param>
		/// <param name="b">The second numebr.</param>
		/// <returns>GCD of two numbers.</returns>
		private static int GetGcdOfTwoNumbers(int a, int b)
		{
			a = Math.Abs(a);
			b = Math.Abs(b);

			if (a == 0 || b == 0)
				return a == 0 ? b : a;

			while ((a %= b) != 0 && (b %= a) != 0) ;

			return a | b;
		}

		/// <summary>
		/// Realization of finding GCD of two numbers by binary algorithm.
		/// </summary>
		/// <param name="a">The first number.</param>
		/// <param name="b">The second numebr.</param>
		/// <returns>GCD of two numbers.</returns>
		private static int GetGcdOfTwoNumbersBinary(int a, int b)
		{
			a = Math.Abs(a);
			b = Math.Abs(b);

			int shift;

			if (a == 0 || b == 0)
				return a == 0 ? b : a;

			for (shift = 0; ((a | b) & 1) == 0; ++shift)
			{
				a >>= 1;
				b >>= 1;
			}

			while ((a & 1) == 0)
				a >>= 1;

			do
			{
				while ((b & 1) == 0)
					b >>= 1;
				if (a > b)
				{
					int t = b;
					b = a;
					a = t;
				}
				b = b - a;
			} while (b != 0);

			return a << shift;
		}
	}
}
