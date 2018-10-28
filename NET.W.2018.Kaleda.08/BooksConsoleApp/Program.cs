using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Entities;
using Books.Services;
using Books.Repositories;

namespace BooksConsoleApp
{
	class Program
	{
		public static IBookListService BooksService { get; set; }

		static Program()
		{
			BooksService = new BookListService(new BinaryBookListRepository());
		}

		static void Main(string[] args)
		{
			var book1 = new Book()
			{
				Isbn = "0-000-00000-0",
				Author = new Author() { FirstName = "Joseph", LastName = "Albahari" },
				Name = "C# 7.0 in a nutshell",
				PublishingHouse = new PublishingHouse() { Name = "O'REILLY" },
				PublishingYear = 2017,
				NumberOfPages = 1040,
				Price = 200,
				Tags = new List<string>() { "programming", "c#" },
			};

			var book2 = new Book()
			{
				Isbn = "0-000-00000-1",
				Author = new Author() { FirstName = "Adam", LastName = "Freeman" },
				Name = "Pro ASP.NET Core MVC 2",
				PublishingHouse = new PublishingHouse() { Name = "Apress" },
				PublishingYear = 2017,
				NumberOfPages = 1024,
				Price = 250,
				Tags = new List<string>() { "programming", "c#", "asp.net" },
			};

			try
			{
				BooksService.AddBook(book1);
				BooksService.AddBook(book2);
			}

			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.WriteLine("Books with tag 'c#':");
			foreach (var book in BooksService.FindBooksByTag("c#"))
			{
				Console.WriteLine(book);
			}

			BooksService.RemoveBook(book1);

			Console.WriteLine("Books with tag 'programming':");
			foreach(var book in BooksService.FindBooksByTag("programming"))
			{
				Console.WriteLine(book);
			}
		}
	}
}
