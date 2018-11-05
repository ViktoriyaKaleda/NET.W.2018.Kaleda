using System;
using System.Globalization;
using Books.Entities;
using Books.Extensions;
using NUnit.Framework;

namespace Books.NUnitTests
{
	[TestFixture]
	public class BooksTests
	{
		public static Book book = new Book()
		{
			Isbn = "978-0-7356-6745-7",
			Title = "CLR via C#",
			Author = new Author() { FirstName = "Jeffrey", LastName = "Richter" },
			PublishingHouse = new PublishingHouse() { Name = "Microsoft Press" },
			PublishingYear = 2012,
			NumberOfPages = 826,
			Price = 59.99M,
		};

		[TestCase("F", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, 59,99 ₽")]
		[TestCase("ATHY", ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012")]
		[TestCase("ATH", ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\"")]
		[TestCase("ATY", ExpectedResult = "Jeffrey Richter, CLR via C#, 2012")]
		[TestCase("AT", ExpectedResult = "Jeffrey Richter, CLR via C#")]
		[TestCase("IAT", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#")]
		[TestCase("IHY", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, \"Microsoft Press\", 2012")]
		[TestCase(null, ExpectedResult = "Jeffrey Richter, CLR via C#")]
		[TestCase("", ExpectedResult = "Jeffrey Richter, CLR via C#")]
		public string ToString_ValidFormat_ValidResult(string format)
		{
			return book.ToString(format);
		}

		[TestCase("F", "ru-RU", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, 59,99 ₽")]
		[TestCase("F", "en-US", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, $59.99")]
		public string ToString_ValidFormat_ValidResult(string format, string culture)
		{
			return book.ToString(format, new CultureInfo(culture));
		}

		[TestCase("AA")]
		[TestCase("ATT")]
		public void ToString_InvalidFormat_FormatException(string format)
			=> Assert.Throws<FormatException>(() => new Book().ToString(format, null));

		[TestCase("T", ExpectedResult = "Title: CLR via C#")]
		[TestCase("A", ExpectedResult = "Author: Jeffrey Richter")]
		[TestCase("PH", ExpectedResult = "Publishing house: \"Microsoft Press\"")]
		[TestCase("PY", ExpectedResult = "Year: 2012")]
		[TestCase("P", ExpectedResult = "Pages: 826")]
		[TestCase("PR", ExpectedResult = "Price: 59,99 ₽")]
		[TestCase(null, ExpectedResult = "Title: CLR via C#")]
		[TestCase("", ExpectedResult = "Title: CLR via C#")]
		public string Format_ValidFormat_ValidResult(string format)
		{
			return new BookFormatExtension().Format(format, book, null);
		}

		[TestCase("PR", "ru-RU", ExpectedResult = "Price: 59,99 ₽")]
		[TestCase("PR", "en-US", ExpectedResult = "Price: $59.99")]
		public string Format_ValidFormat_ValidResult(string format, string culture)
		{
			return new BookFormatExtension().Format(format, book, new CultureInfo(culture));
		}

		[TestCase(ExpectedResult = "Title: CLR via C#, Year: 2012")]
		public string Format_ValidFormat_ValidResult()
		{
			return String.Format(new BookFormatExtension(), "{0:T}, {0:PY}", book);
		}

		[TestCase("AA")]
		[TestCase("ATT")]
		public void Format_InvalidFormat_FormatException(string format)
			=> Assert.Throws<FormatException>(() => new BookFormatExtension().Format(format, book, null));
	}
}
