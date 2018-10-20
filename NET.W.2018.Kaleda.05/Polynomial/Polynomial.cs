using System;
using System.Collections.Generic;

namespace Polynomial
{
	public sealed class Polynomial : IEquatable<Polynomial>
	{
		private const double accuracy = 1e-10;

		public double[] Coefficients { get; private set; }

		public int Degree { get => Coefficients.Length - 1; }

		public Polynomial(params double[] coefficients)
		{
			if (coefficients == Array.Empty<double>())
				throw new ArgumentException("The array can not be empty.", nameof(coefficients));

			if (coefficients == null)
				throw new ArgumentNullException(nameof(coefficients), "The value can not be undefined.");

			Coefficients = new double[coefficients.Length];
			Array.Copy(coefficients, Coefficients, coefficients.Length);
		}

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

		public bool Equals(Polynomial other)
		{
			if (this.Degree != other.Degree)
				return false;

			for (int i = 0; i < Coefficients.Length; i++)
				if (Math.Abs(this.Coefficients[i] - other.Coefficients[i]) > accuracy)
					return false;

			return true;
		}

		public override bool Equals(object other)
		{
			if (other is Polynomial)
			{
				return Equals((Polynomial)other);
			}
			return false;
		}

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

		public static bool operator ==(Polynomial p1, Polynomial p2)
			=> p1.Equals(p2);

		public static bool operator !=(Polynomial p1, Polynomial p2)
			=> !(p1.Equals(p2));

		public static Polynomial operator +(Polynomial p1, Polynomial p2)
		{
			(p1, p2) = TransformToSameDegree(p1, p2);
			var resultCoefficients = new double[p1.Coefficients.Length];

			for (int i = 0; i < resultCoefficients.Length; i++)
				resultCoefficients[i] = p1[i] + p2[i];

			return new Polynomial(resultCoefficients);
		}

		public static Polynomial operator +(Polynomial p, double number)
			=> p.Add(number);

		public static Polynomial operator +(double number, Polynomial p)
			=> p.Add(number);

		public static Polynomial operator -(Polynomial p1, Polynomial p2)
		{
			(p1, p2) = TransformToSameDegree(p1, p2);
			var resultCoefficients = new double[p1.Coefficients.Length];

			for (int i = 0; i < resultCoefficients.Length; i++)
				resultCoefficients[i] = p1[i] - p2[i];

			return new Polynomial(resultCoefficients);
		}

		public static Polynomial operator -(Polynomial p, double number)
			=> p.Subtract(number);

		public static Polynomial operator -(double number, Polynomial p)
			=> new Polynomial(number) - p;

		public Polynomial Add(Polynomial p)
			=> this + p;

		public Polynomial Add(double number)
		{
			var resultCoefficients = new double[Coefficients.Length];
			Array.Copy(Coefficients, resultCoefficients, resultCoefficients.Length);
			resultCoefficients[resultCoefficients.Length - 1] += number;
			return new Polynomial(resultCoefficients);
		}

		public Polynomial Subtract(Polynomial p)
			=> this - p;

		public Polynomial Subtract(double number)
		{
			var resultCoefficients = new double[Coefficients.Length];
			Array.Copy(Coefficients, resultCoefficients, resultCoefficients.Length);
			resultCoefficients[resultCoefficients.Length - 1] -= number;
			return new Polynomial(resultCoefficients);
		}

		public override string ToString()
		{
			List<string> result = new List<string>();

			for (int i = 0; i < Degree; i++)
			{
				if (Coefficients[i] != 0)
					result.Add($"{Coefficients[i].ToString()}*x^{Degree - i}");
			}

			if (Coefficients[Degree] != 0)
				result.Add($"{Coefficients[Degree]}");

			return String.Join(" + ", result);
		}

		private static (Polynomial p1, Polynomial p2) TransformToSameDegree(Polynomial p1, Polynomial p2)
		{
			if (p1.Degree > p2.Degree)
				Swap(ref p1, ref p2);

			var smallerPolynomialCoefficients = new double[p2.Coefficients.Length];
			Array.Copy(p1.Coefficients, 0, smallerPolynomialCoefficients, p2.Coefficients.Length - p1.Coefficients.Length, p1.Coefficients.Length);

			var smallerPolynomial = new Polynomial(smallerPolynomialCoefficients);
			var biggerPolynomial = p2;

			return p1.Degree > p2.Degree ? (biggerPolynomial, smallerPolynomial) : (smallerPolynomial, biggerPolynomial);
		}

		private static void Swap(ref Polynomial p1, ref Polynomial p2)
		{
			var temp = p1;
			p1 = p2;
			p2 = temp;
		}
	}
}
