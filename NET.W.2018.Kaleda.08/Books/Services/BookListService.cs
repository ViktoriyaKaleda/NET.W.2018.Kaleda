using System;
using System.Collections.Generic;
using System.Linq;
using Books.Entities;
using Books.Repositories;
using NLog;

namespace Books.Services
{
	/// <summary>
	/// Implementation of <see cref="IBookListService"/> interface.
	/// </summary>
	public class BookListService : IBookListService
	{
		/// <summary>
		/// Repository for storing and manipulation with books.
		/// </summary>
		private IBookListRepository _repository;

		/// <summary>
		/// Logger.
		/// </summary>
		private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Initializes books repository.
		/// </summary>
		/// <param name="bookListRepository">Book list repository.</param>
		public BookListService(IBookListRepository bookListRepository)
		{
			_repository = bookListRepository;
		}

		/// <summary>
		/// Add new book to book list and save changes.
		/// </summary>
		/// <param name="book">New book for adding.</param>
		/// <exception cref="ArgumentException">Throws when book is already exists in book list.</exception>
		public void AddBook(Book book)
		{
			_repository.AddBook(book);
			_repository.SaveBookList();
			logger.Info($"Book with ISBN {book.Isbn} are added.");
		}

		/// <summary>
		/// Returns books list that contains passed tag.
		/// </summary>
		/// <param name="tag">Tag for searching.</param>
		/// <returns>Returns books list that contains passed tag.</returns>
		public List<Book> FindBooksByTag(string tag)
		{
			var result = new List<Book>();
			foreach (var book in _repository.Books)
			{
				if (book.Tags.Contains(tag))
					result.Add(book);
			}
			return result;
		}

		/// <summary>
		/// Removes book from books list and save changes in repository.
		/// </summary>
		/// <param name="book">Book for removing.</param>
		/// <exception cref="ArithmeticException">Throws when book is not exists in books list.</exception>
		public void RemoveBook(Book book)
		{
			_repository.RemoveBook(book);
			_repository.SaveBookList();
			logger.Info($"Book with ISBN {book.Isbn} are deleted.");
		}

		/// <summary>
		/// Sorts books list by passed comparer.
		/// </summary>
		/// <param name="comparer">The comparer for sorting.</param>
		public void SortBooksByTag(IComparer<Book> comparer)
		{
			_repository.Books = _repository.Books.OrderBy(x => x, comparer).ToList();
			_repository.SaveBookList();
			logger.Info($"Books list was sorted.");
		}
	}
}
