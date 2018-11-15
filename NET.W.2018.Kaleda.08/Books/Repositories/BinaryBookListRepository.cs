using System;
using System.Collections.Generic;
using System.IO;
using Books.Entities;
using NLog;

namespace Books.Repositories
{
	/// <summary>
	/// Implementation of <see cref="IBookListRepository"/> for managing books that stores data in binary file.
	/// </summary>
	public class BinaryBookListRepository : IBookListRepository
	{
		/// <summary>
		/// Collection of books.
		/// </summary>
		public List<Book> Books { get; set; }

		/// <summary>
		/// Name of file for storing data.
		/// </summary>
		private string RepositoryFileName { get; }

		/// <summary>
		/// Logger.
		/// </summary>
		private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Reads data from binary file and initialize Books collection property.
		/// </summary>
		public BinaryBookListRepository()
		{
			Books = new List<Book>();

			RepositoryFileName = Settings.Default.BinaryRepositoryName;

			if (!File.Exists(RepositoryFileName))
				return;

			Stream stream = File.OpenRead(RepositoryFileName);
			using (var reader = new BinaryReader(stream))
			{
				int count = reader.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					string isbn = reader.ReadString();
					string authorFirstName = reader.ReadString();
					string authorLastName = reader.ReadString();
					string bookName = reader.ReadString();
					string publishingHouseName = reader.ReadString();
					int publishingYear = reader.ReadInt32();
					int numberOfPages = reader.ReadInt32();
					decimal price = reader.ReadDecimal();

					int numberOfTags = reader.ReadInt32();
					var tags = new List<string>();
					for (int j = 0; j < numberOfTags; j++)
					{
						tags.Add(reader.ReadString());
					}

					var author = new Author() { FirstName = authorFirstName, LastName = authorLastName };
					var publishingHouse = new PublishingHouse() { Name = publishingHouseName };

					Books.Add(new Book()
					{
						Isbn = isbn,
						Author = author,
						Title = bookName,
						PublishingHouse = publishingHouse,
						PublishingYear = publishingYear,
						NumberOfPages = numberOfPages,
						Price = price,
						Tags = tags
					});
				}
			}
		}

		/// <summary>
		/// Add book to Books collection property.
		/// </summary>
		/// <param name="book"></param>
		public void AddBook(Book book)
		{
			if (Books.Contains(book))
			{
				logger.Warn($"Adding already existing book to list, book Isnb: {book.Isbn}");
				throw new ArgumentException("This element is already exists.", nameof(book));
			}

			Books.Add(book);
		}

		/// <summary>
		/// Clears Books collection property.
		/// </summary>
		public void ClearBookList()
		{
			Books.Clear();
		}

		/// <summary>
		/// Removes book from Books collection property.
		/// </summary>
		/// <param name="book"></param>
		public void RemoveBook(Book book)
		{
			if (Books.Remove(book) == false)
			{
				logger.Warn($"Removing book that is not exist to list, book Isnb: {book.Isbn}");
				throw new ArgumentException("Element not found in list.", nameof(book));
			}
		}

		/// <summary>
		/// Save Books collection property to binary file.
		/// </summary>
		public void SaveBookList()
		{
			Stream stream = File.Create(RepositoryFileName);
			using (var writer = new BinaryWriter(stream))
			{
				writer.Write(Books.Count);

				foreach (var book in Books)
				{
					writer.Write(book.Isbn);
					writer.Write(book.Author.FirstName);
					writer.Write(book.Author.LastName);
					writer.Write(book.Title);
					writer.Write(book.PublishingHouse.Name);
					writer.Write(book.PublishingYear);
					writer.Write(book.NumberOfPages);
					writer.Write(book.Price);

					writer.Write(book.Tags.Count);
					foreach (var tag in book.Tags)
						writer.Write(tag);
				}			
			}
			logger.Info("Book list saved.");
		}

		/// <summary>
		/// Update book in Book collection property.
		/// </summary>
		/// <param name="book"></param>
		public void UpdateBook(Book book)
		{
			for (int i = 0; i < Books.Count; i++)
				if (Books[i].Equals(book))
					Books[i] = book;

			throw new ArgumentException("Element not found in list.", nameof(book));
		}
	}
}
