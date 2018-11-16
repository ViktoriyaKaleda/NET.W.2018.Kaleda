using System;
using System.Collections.Generic;
using System.Globalization;

namespace Books.Entities
{
	public class Book : IEquatable<Book>, IComparable<Book>, IFormattable
	{
		/// <summary>
		/// ISBN of the book.
		/// </summary>
		public string Isbn { get; set; }

		/// <summary>
		/// Author of the book.
		/// </summary>
		public Author Author { get; set; }

		/// <summary>
		/// Book name.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// House of publishing of the book.
		/// </summary>
		public PublishingHouse PublishingHouse { get; set; }

		/// <summary>
		/// Year of publishing of the book.
		/// </summary>
		private int publishingYear;
		public int PublishingYear
		{
			get => publishingYear;
			set
			{
				if (value < 0 || value > DateTime.Now.Year)
					throw new ArgumentOutOfRangeException(nameof(value), "Incorrect value for year.");

				publishingYear = value;
			}
		}

		/// <summary>
		/// Number of pages of the book.
		/// </summary>
		private int numberOfPages;
		public int NumberOfPages
		{
			get => numberOfPages;
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(value), "Non negative value expected.");

				numberOfPages = value;
			}
		}

		/// <summary>
		/// Price of the book.
		/// </summary>
		private decimal price;
		public decimal Price
		{
			get => price;
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(value), "Non negative value expected.");

				price = value;
			}
		}

		/// <summary>
		/// The book tags.
		/// </summary>
		public List<string> Tags { get; set; }

		private static string DefaultFormat { get => "AT"; }

		/// <summary>
		/// Returns true if passed book is equals to current or false otherwise.
		/// </summary>
		/// <param name="book">The book to comparison.</param>
		/// <returns>True if passed book is equals to current or false otherwise.</returns>
		public bool Equals(Book book)
		{
			if ((object)book == null)
				return false;

			return this.Isbn.Equals(book.Isbn);
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

			if (other is Book)
				return Equals((Book)other);
			
			return false;
		}

		/// <summary>
		/// Returns hash code of the book.
		/// </summary>
		/// <returns>The hash code of the book.</returns>
		public override int GetHashCode()
		{
			return this.Isbn.GetHashCode();
		}

		public override string ToString()
		{
			return ToString(DefaultFormat, null);
		}

		public string ToString(string format)
			=> ToString(format, CultureInfo.CurrentCulture);

		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (string.IsNullOrEmpty(format))
				format = DefaultFormat;

			if (formatProvider == null)
				formatProvider = CultureInfo.CurrentCulture;

			switch (format.ToUpper())
			{
				case "F":
					return string.Format(formatProvider, "ISBN 13: {0}, {1}, {2}, \"{3}\", {4}, P. {5}, {6:C}", 
						Isbn, Author, Title, PublishingHouse, PublishingYear, NumberOfPages, Price);

				case "ATHY":
					return $"{Author}, {Title}, \"{PublishingHouse}\", {PublishingYear}";

				case "ATH":
					return $"{Author}, {Title}, \"{PublishingHouse}\"";

				case "ATY":
					return $"{Author}, {Title}, {PublishingYear}";

				case "AT":
					return $"{Author}, {Title}";

				case "IAT":
					return $"ISBN 13: {Isbn}, {Author}, {Title}";

				case "IHY":
					return $"ISBN 13: {Isbn}, \"{PublishingHouse}\", {PublishingYear}";

				default:
					throw new FormatException($"Unknown format: {format}.");
			}
		}

		/// <summary>
		/// Provides comparison of two books objects by their titles.
		/// </summary>
		/// <param name="other">Book to comparer.</param>
		/// <returns></returns>
		public int CompareTo(Book other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other), "Value can not be underfined");

			return this.Title.CompareTo(other.Title);
		}
	}
}
