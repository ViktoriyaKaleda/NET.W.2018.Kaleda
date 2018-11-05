using System;
using System.Collections.Generic;
using System.IO;
using Books.Entities;

namespace Books.Repositories
{
	public class BinaryBookListRepository : IBookListRepository
	{
		public List<Book> Books { get; set; }

		private string RepositoryFileName { get; } 

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

		public void AddBook(Book book)
		{
			if (Books.Contains(book))
				throw new ArgumentException("This element is already exists.", nameof(book));

			Books.Add(book);
		}

		public void ClearBookList()
		{
			Books.Clear();
		}

		public void RemoveBook(Book book)
		{
			if (Books.Remove(book) == false)
				throw new ArgumentException("Element not found in list.", nameof(book));
		}

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
		}

		public void UpdateBook(Book book)
		{
			for (int i = 0; i < Books.Count; i++)
				if (Books[i].Equals(book))
					Books[i] = book;

			throw new ArgumentException("Element not found in list.", nameof(book));
		}
	}
}
