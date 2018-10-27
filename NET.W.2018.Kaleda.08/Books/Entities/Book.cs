using System;

namespace Books.Entities
{
	public class Book : IEquatable<Book>
	{
		/// <summary>
		/// ISBN of the book.
		/// </summary>
		public Guid Isbn { get; set; }

		/// <summary>
		/// Author of the book.
		/// </summary>
		public Author Author { get; set; }

		/// <summary>
		/// Book name.
		/// </summary>
		public string Name { get; set; }

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
		/// Returns true if passed book is equals to current or false otherwise.
		/// </summary>
		/// <param name="book">The book to comparison.</param>
		/// <returns>True if passed book is equals to current or false otherwise.</returns>
		public bool Equals(Book book)
		{
			if (this.Isbn.Equals(book.Isbn))
				return true;

			return false;
		}

		/// <summary>
		/// Returns true if passed object is equals to current or false otherwise.
		/// </summary>
		/// <param name="other">Object to comparison.</param>
		/// <returns>True if passed object is equals to current or false otherwise.</returns>
		public override bool Equals(object other)
		{
			if (other is Book)
			{
				return Equals((Book)other);
			}
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
	}
}
