using System;

namespace NthRoot
{
	public static class NthRoot
    {
		/// <summary>
		/// Returns nth root of a number.
		/// </summary>
		/// <param name="number">The number to take the root.</param>
		/// <param name="n">The degree.</param>
		/// <param name="accuracy">The accuracy of the result.</param>
		/// <returns>The root of nth degree.</returns>
		public static double FindNthRoot(double number, int n, double accuracy)
		{
			CheckParameters(n, accuracy);

			double previousX = number / 2.0;
			double currentX;

			while(true)
			{
				currentX = ((n - 1) * previousX + (number / Math.Pow(previousX,  n - 1))) / n;

				if (Math.Abs(previousX - currentX) < accuracy)
					break;

				previousX = currentX;
			}

			return currentX;
		}

		/// <summary>
		/// Checks if passed degree and accuracy are valid.
		/// </summary>
		/// <param name="n">The degree.</param>
		/// <param name="accuracy">The accuracy of the result.</param>
		private static void CheckParameters(int n, double accuracy)
		{
			if (n <= 0)
				throw new ArgumentOutOfRangeException(nameof(n), "Value should be greater than 0.");

			if (accuracy < 0)
				throw new ArgumentOutOfRangeException(nameof(accuracy), "Non negative number expected.");
		}
    }
}
