using NUnit.Framework;
using System;

namespace Polinomial.NUnitTests
{
	[TestFixture]
	public class PolynomialTests
	{
		[Test]
		public void Constructor_EmptyArray_ArgumentException()
			=> Assert.Throws<ArgumentException>(() => new Polynomial.Polynomial(new double[0]));

		[Test]
		public void Constructor_NullArray_ArgumentException()
			=> Assert.Throws<ArgumentNullException>(() => new Polynomial.Polynomial(null));

		[TestCaseSource("SamePolynomials")]
		public void GetHashCode_SamePolynomials_EqualsHashCodes(double[] coefficients1, double[] coefficients2)
		{
			Assert.That(new Polynomial.Polynomial(coefficients1).GetHashCode(), Is.EqualTo(new Polynomial.Polynomial(coefficients2).GetHashCode()));
		}

		[TestCase(new double[] { 1 }, 0)]
		[TestCase(new double[] { 1, 2 }, 1)]
		[TestCase(new double[] { 1, 2, 3 }, 2)]
		[TestCase(new double[] { 0, 1, 2, 3 }, 2)]
		public void Degree_Polynomial_DegreeOfPolynomial(double[] coefficients, int expectedResult)
		{
			var p = new Polynomial.Polynomial(coefficients);

			Assert.That(p.Degree, Is.EqualTo(expectedResult));
		}

		[Test]
		public void GetHashCode_DifferentPolynomials_DifferentHashCodes()
		{
			var p1 = new Polynomial.Polynomial(new double[] { 1, 2, 3 });
			var p2 = new Polynomial.Polynomial(new double[] { 1, 2, 0 });
			Assert.AreNotEqual(p1.GetHashCode(), p2.GetHashCode());
		}

		[TestCaseSource("SamePolynomials")]
		public void Equals_SamePolynomials_True(double[] coefficients1, double[] coefficients2)
		{
			var p1 = new Polynomial.Polynomial(coefficients1);
			var p2 = new Polynomial.Polynomial(coefficients2);

			Assert.That(p1.Equals(p2), Is.True);
			Assert.That(p1.Equals((object)p2), Is.True);
			Assert.That(p2.Equals(p1), Is.True);
			Assert.That(p1 == p2, Is.True);
		}

		[Test]
		public void Equals_NullParameter_False()
		{
			var p1 = new Polynomial.Polynomial(new double[] { 1 });
			Polynomial.Polynomial p2 = null;

			Assert.That(p1.Equals(p2), Is.False);
			Assert.That(p1.Equals((object)p2), Is.False);
		}

		[TestCaseSource("AdditionParametersCases")]
		public void PlusOperator_ValidData_Sum(double[] coefficents1, double[] coefficents2, double[] expectedResult)
		{
			var p1 = new Polynomial.Polynomial(coefficents1);
			var p2 = new Polynomial.Polynomial(coefficents2);
			var result = p1 + p2;

			CollectionAssert.AreEqual(result.Coefficients, expectedResult);
		}

		[TestCaseSource("AdditionParametersCases")]
		public void Add_ValidData_Sum(double[] coefficents1, double[] coefficents2, double[] expectedResult)
		{
			var p1 = new Polynomial.Polynomial(coefficents1);
			var p2 = new Polynomial.Polynomial(coefficents2);
			var result = p1.Add(p2);

			CollectionAssert.AreEqual(result.Coefficients, expectedResult);
		}

		[TestCaseSource("SubtractionParametersCases")]
		public void MinusOperator_ValidData_ValidResult(double[] coefficents1, double[] coefficents2, double[] expectedResult)
		{
			var p1 = new Polynomial.Polynomial(coefficents1);
			var p2 = new Polynomial.Polynomial(coefficents2);
			var result = p1 - p2;

			CollectionAssert.AreEqual(result.Coefficients, expectedResult);
		}

		[TestCaseSource("SubtractionParametersCases")]
		public void Substract_ValidData_ValidResult(double[] coefficents1, double[] coefficents2, double[] expectedResult)
		{
			var p1 = new Polynomial.Polynomial(coefficents1);
			var p2 = new Polynomial.Polynomial(coefficents2);
			var result = p1.Subtract(p2);

			CollectionAssert.AreEqual(result.Coefficients, expectedResult);
		}

		[TestCaseSource("MultiplicationParametersCases")]
		public void MultiplyOperator_ValidData_Composition(double[] coefficents1, double[] coefficents2, double[] expectedResult)
		{
			var p1 = new Polynomial.Polynomial(coefficents1);
			var p2 = new Polynomial.Polynomial(coefficents2);
			var result = p1 * p2;

			CollectionAssert.AreEqual(result.Coefficients, expectedResult);
		}

		[TestCaseSource("MultiplicationParametersCases")]
		public void Multiply_ValidData_Compositoin(double[] coefficents1, double[] coefficents2, double[] expectedResult)
		{
			var p1 = new Polynomial.Polynomial(coefficents1);
			var p2 = new Polynomial.Polynomial(coefficents2);
			var result = p1.Multiply(p2);

			CollectionAssert.AreEqual(result.Coefficients, expectedResult);
		}

		[TestCase(new double[] { 1, 2, 3 }, "x^2 + 2*x + 3")]
		[TestCase(new double[] { 0 }, "")]
		[TestCase(new double[] { 1 }, "1")]
		[TestCase(new double[] { 1, 2, 0, 3 }, "x^3 + 2*x^2 + 3")]
		[TestCase(new double[] { 1, 2, 0, 0 }, "x^3 + 2*x^2")]
		public static void ToString_ValidData_StringReprezentation(double[] coefficients, string expectedResult)
		{
			var p = new Polynomial.Polynomial(coefficients);

			Assert.That(p.ToString(), Is.EqualTo(expectedResult));
		}

		public static object[] SamePolynomials =
		{
			new object[] {new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 } },
			new object[] {new double[] { 0, 1, 2 }, new double[] { 1, 2 } },
			new object[] {new double[] { 0 }, new double[] { 0 } }
		};

		public static object[] AdditionParametersCases =
		{
			new object[] {new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 6 } },
			new object[] {new double[] { -1, -3, 4 }, new double[] { 1, 2, 0 }, new double[] { 0, -1, 4 } },
			new object[] {new double[] { 1 }, new double[] { 1 }, new double[] { 2 } },
			new object[] {new double[] { 1 }, new double[] { 0 }, new double[] { 1 } },
			new object[] {new double[] { 0 }, new double[] { 5, 2, 1 }, new double[] { 5, 2, 1 } }
		};

		public static object[] SubtractionParametersCases =
		{
			new object[]{ new double[] { 1 }, new double[] { 1 }, new double[] { 0 } },
			new object[] { new double[] { 1, 2, 3 }, new double[] { 2 }, new double[] { 1, 2, 1 } },
			new object[] { new double[] { 5, 5, 5 }, new double[] { 1, 2, 3 }, new double[] { 4, 3, 2 } },
			new object[] { new double[] { 1, 2, 3 }, new double[] { 0 }, new double[] { 1, 2, 3 } },
			new object[] { new double[] { 0 }, new double[] { 5, 2, 1 }, new double[] { -5, -2, -1 } },
			new object[] { new double[] { 2, 3, 4 }, new double[] { 3, 4, 5 }, new double[] { -1, -1, -1 } }
		};

		public static object[] MultiplicationParametersCases =
		{
			new object[] {new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 1, 4, 10, 12, 9 } },
			new object[] {new double[] { -1, -3, 4 }, new double[] { 1 }, new double[] { -1, -3, 4 } },
			new object[] {new double[] { -1, -3, 4 }, new double[] { 1, 2, 3 }, new double[] { -1, -5, -5, -1, 12 } },
			new object[] {new double[] { 1 }, new double[] { 1 }, new double[] { 1 } },
			new object[] {new double[] { 1 }, new double[] { 0 }, new double[] { 0 } },
			new object[] {new double[] { 0 }, new double[] { 5, 2, 1 }, new double[] { 0, 0, 0 } }
		};
	}
}
