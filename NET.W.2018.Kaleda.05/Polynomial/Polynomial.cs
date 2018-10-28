using System;
using System.Collections.Generic;

namespace Polynomial
{
	/// <summary>
	/// Immutable class for working with polynomials.
	/// </summary>
	public sealed class Polynomial : IEquatable<Polynomial>, ICloneable
	{
		/// <summary>
		/// Constant that contains accuracy of operations with polynomial.
		/// </summary>
		private const double accuracy = 1e-10;

		/// <summary>
		/// Property that contains coefficients of the polynomial.
		/// </summary>
		public double[] Coefficients { get; private set; }

		/// <summary>
		/// The degree of the polynomial.
		/// </summary>
		public int Degree
		{
			get
			{
				for (int i = 0; i < Coefficients.Length; i++)
					if (Coefficients[i] != 0)
						return Coefficients.Length - i - 1;
				return 0;
			}
		}

		/// <summary>
		/// Initialize new instance of Polynomial class. 
		/// </summary>
		/// <param name="coefficients">
		/// Values of polynomial coefficients. 
		/// The first value is the coefficient of the highest degree, 
		/// the last value will be the free member.
		/// </param>
		/// <exception cref="ArgumentException">Throws when passed array is empty.</exception>
		/// <exception cref="ArgumentNullException">Throws when passed array is null.</exception>
		public Polynomial(params double[] coefficients)
		{
			if (coefficients == null)
				throw new ArgumentNullException(nameof(coefficients), "The value can not be undefined.");

			if (coefficients.Length == 0)
				throw new ArgumentException("The array can not be empty.", nameof(coefficients));			

			Coefficients = new double[coefficients.Length];
			Array.Copy(coefficients, Coefficients, coefficients.Length);
		}

		/// <summary>
		/// Indexator which get access to coefficient with passed index.
		/// </summary>
		/// <param name="index">Index in the coefficient array.</param>
		/// <exception cref="ArgumentOutOfRangeException">Throws when passed index is negative
		/// or greater than the coefficients array length - 1.</exception>
		public double this[int index]
		{
			get
			{
				if (index < 0 || index > Coefficients.Length)
					throw new ArgumentOutOfRangeException(nameof(index), "Non negative value that is not bigger than the number of coefficients expected.");

				return Coefficients[index];
			}
			private set
			{
				if (index < 0 || index > Coefficients.Length)
					throw new ArgumentOutOfRangeException(nameof(index), "Non negative value that is not bigger than the number of coefficients expected.");

				Coefficients[index] = value;
			}
		}

		/// <summary>
		/// Returns true if passed polynomial is equals to current or false otherwise.
		/// </summary>
		/// <param name="other">Polynomial to comparison.</param>
		/// <returns>True if passed polynomial is equals to current or false otherwise.</returns>
		public bool Equals(Polynomial other)
		{
			if ((object)other == null)
				return false;

			if (this.Degree != other.Degree)
				return false;

			var current = this;
			(current, other) = TransformToSameLength(this, other);

			for (int i = 0; i < Coefficients.Length; i++)
				if (Math.Abs(current.Coefficients[i] - other.Coefficients[i]) > accuracy)
					return false;

			return true;
		}

		/// <summary>
		/// Returns true if passed object is equals to current or false otherwise.
		/// </summary>
		/// <param name="other">Object to comparison.</param>
		/// <returns>True if passed object is equals to current or false otherwise.</returns>
		public override bool Equals(object other)
		{
			if (other == null)
				return false;

			if (other is Polynomial)
			{
				return Equals((Polynomial)other);
			}
			return false;
		}

		/// <summary>
		/// Returns hash code of the polynomial.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			int hash = 0;
			const int primeMultiplier = 23;
			unchecked
			{
				for (int i = 0; i < Coefficients.Length; i++)
				{
					hash += primeMultiplier * (int)Coefficients[i];
				}
			}
			return hash;
		}

		/// <summary>
		/// Returns true if passed polynomials are equals or false otherwise.
		/// </summary>
		/// <param name="other">Object to comparison.</param>
		/// <returns>True if passed polynomials are equals or false otherwise.</returns>
		public static bool operator ==(Polynomial p1, Polynomial p2)
			=> p1.Equals(p2);

		public static bool operator !=(Polynomial p1, Polynomial p2)
			=> !(p1.Equals(p2));

		/// <summary>
		/// Clones this polynomial.
		/// </summary>
		/// <returns>The clone of this polynomial.</returns>
		public Polynomial Clone()
			=> new Polynomial(this.Coefficients);

		/// <summary>
		/// Clones this polynomial.
		/// </summary>
		/// <returns>The clone of this polynomial.</returns>
		object ICloneable.Clone()
			=> this.Clone();

		/// <summary>
		/// Adds number to polynomial.
		/// </summary>
		/// <param name="p1">The first polynomial.</param>
		/// <param name="p2">The second polynomial.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator +(Polynomial p1, Polynomial p2)
		{
			(p1, p2) = TransformToSameLength(p1, p2);
			var resultCoefficients = new double[p1.Coefficients.Length];

			for (int i = 0; i < resultCoefficients.Length; i++)
				resultCoefficients[i] = p1[i] + p2[i];

			return new Polynomial(resultCoefficients);
		}

		/// <summary>
		/// Adds number to polynomial.
		/// </summary>
		/// <param name="p">The polynomial to add.</param>
		/// <param name="number">The number to add.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator +(Polynomial p, double number)
			=> p.Add(number);

		/// <summary>
		/// Adds number to polynomial.
		/// </summary>
		/// <param name="number">The number to add.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator +(double number, Polynomial p)
			=> p.Add(number);

		/// <summary>
		/// Subtracts the second polynomial from the first.
		/// </summary>
		/// <param name="p1">The fisrt polynomial.</param>
		/// <param name="p2">The second polynomial.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator -(Polynomial p1, Polynomial p2)
		{
			(p1, p2) = TransformToSameLength(p1, p2);
			var resultCoefficients = new double[p1.Coefficients.Length];

			for (int i = 0; i < resultCoefficients.Length; i++)
				resultCoefficients[i] = p1[i] - p2[i];

			return new Polynomial(resultCoefficients);
		}

		/// <summary>
		/// Subtracts number from polynomial.
		/// </summary>
		/// <param name="p">The polynomial from which subtract.</param>
		/// <param name="number">The number which subtract from the polynomial.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator -(Polynomial p, double number)
			=> p.Subtract(number);

		/// <summary>
		/// Subtracts polynomial from number.
		/// </summary>
		/// <param name="number">The number from which subtract.</param>
		/// <param name="p">The polynomial which subtract from the number.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator -(double number, Polynomial p)
			=> new Polynomial(number) - p;
		
		/// <summary>
		/// Multiply the first polynomial by the second.
		/// </summary>
		/// <param name="p1">The first polynomial.</param>
		/// <param name="p2">The second polynomial.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator *(Polynomial p1, Polynomial p2)
		{
			var singlePolynomial = new Polynomial(new double[] { 1 });
			if (p1 == singlePolynomial || p2 == singlePolynomial)
				return p1 == singlePolynomial ? p2 : p1;

			(p1, p2) = TransformToSameLength(p1, p2);
			var resultCoefficients = new double[p1.Degree + p2.Degree + 1];

			for (int i = 0; i <= p1.Degree; i++)
			{
				for (int j = 0; j <= p2.Degree; j++)
				{
					resultCoefficients[i + j] += p1[i] * p2[j];
				}
			}

			return new Polynomial(resultCoefficients);
		}

		/// <summary>
		/// Multiply the passed polynomial by the number.
		/// </summary>
		/// <param name="p">The polynomial for multiplying.</param>
		/// <param name="number">The number for multiplying.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator *(Polynomial p, double number)
			=> p.Multiply(number);

		/// <summary>
		/// Multiply the passed polynomial by the number.
		/// </summary>
		/// <param name="number">The number for multiplying.</param>
		/// <param name="p">The polynomial for multiplying.</param>
		/// <returns>Result polynomial.</returns>
		public static Polynomial operator *(double number, Polynomial p)
			=> p.Multiply(number);

		/// <summary>
		/// Adds passed polynomial to current.
		/// </summary>
		/// <param name="number">The polynomial to add.</param>
		/// <returns>Result polynomial.</returns>
		public Polynomial Add(Polynomial p)
			=> this + p;

		/// <summary>
		/// Adds number to polynomial.
		/// </summary>
		/// <param name="number">The number to add.</param>
		/// <returns>Result polynomial.</returns>
		public Polynomial Add(double number)
		{
			var resultCoefficients = new double[Coefficients.Length];
			Array.Copy(Coefficients, resultCoefficients, resultCoefficients.Length);
			resultCoefficients[resultCoefficients.Length - 1] += number;
			return new Polynomial(resultCoefficients);
		}

		/// <summary>
		/// Subtracts passed polynomial from current.
		/// </summary>
		/// <param name="number">The number to subtract.</param>
		/// <returns>Result polynomial.</returns>
		public Polynomial Subtract(Polynomial p)
			=> this - p;

		/// <summary>
		/// Subtracts number from polynomial.
		/// </summary>
		/// <param name="number">The number to subtract.</param>
		/// <returns>Result polynomial.</returns>
		public Polynomial Subtract(double number)
		{
			var resultCoefficients = new double[Coefficients.Length];
			Array.Copy(Coefficients, resultCoefficients, resultCoefficients.Length);
			resultCoefficients[resultCoefficients.Length - 1] -= number;
			return new Polynomial(resultCoefficients);
		}

		/// <summary>
		/// Multiply the current polynomial by the passed.
		/// </summary>
		/// <param name="p">The polynomial for multiplying.</param>
		/// <returns>Result polynomial.</returns>
		public Polynomial Multiply(Polynomial p)
			=> this * p;

		/// <summary>
		/// Multiply the current polynomial by the passed number.
		/// </summary>
		/// <param name="p">The number for multiplying.</param>
		/// <returns>Result polynomial.</returns>
		public Polynomial Multiply(double number)
		{
			var resultCoefficients = new double[this.Coefficients.Length];

			for (int i = 0; i < this.Coefficients.Length; i++)
				resultCoefficients[i] = this[i] * number;

			return new Polynomial(resultCoefficients);
		}

		/// <summary>
		/// Returns polynomial string reprezentation.
		/// </summary>
		/// <returns>Polynomial string reprezentation.</returns>
		public override string ToString()
		{
			List<string> result = new List<string>();
			int length = Coefficients.Length - 1;

			for (int i = 0; i < length; i++)
			{
				if (Coefficients[i] != 0)
				{
					if (Coefficients[i] == 1)
						result.Add("x" + (length - i == 1 ? "" : $"^{length - i}"));
					else
						result.Add($"{Coefficients[i].ToString()}*x" + (length - i == 1 ? "" : $"^{length - i}"));
				}
			}

			if (Coefficients[length] != 0)
				result.Add($"{Coefficients[length]}");

			return String.Join(" + ", result);
		}

		/// <summary>
		/// Expand the smallest coefficients array of two polynomials by filling the highest degrees with 0.
		/// </summary>
		/// <param name="p1">The fist polynomial.</param>
		/// <param name="p2">The second polynomial.</param>
		/// <returns>Two polynomials with the same coefficients array size in the same order that passed.</returns>
		private static (Polynomial p1, Polynomial p2) TransformToSameLength(Polynomial p1, Polynomial p2)
		{
			bool isSwapped = false;
			if (p1.Coefficients.Length > p2.Coefficients.Length)
			{
				Swap(ref p1, ref p2);
				isSwapped = true;
			}

			var smallerPolynomialCoefficients = new double[p2.Coefficients.Length];
			Array.Copy(p1.Coefficients, 0, smallerPolynomialCoefficients, p2.Coefficients.Length - p1.Coefficients.Length, p1.Coefficients.Length);

			var smallerPolynomial = new Polynomial(smallerPolynomialCoefficients);
			var biggerPolynomial = p2;

			return isSwapped ? (biggerPolynomial, smallerPolynomial) : (smallerPolynomial, biggerPolynomial);
		}

		/// <summary>
		/// Swap to polynomial objects.
		/// </summary>
		/// <param name="p1">The first value to swap.</param>
		/// <param name="p2">The second value to swap.</param>
		private static void Swap(ref Polynomial p1, ref Polynomial p2)
		{
			var temp = p1;
			p1 = p2;
			p2 = temp;
		}
	}
}
