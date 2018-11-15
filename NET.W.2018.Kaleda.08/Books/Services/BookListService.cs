using System.Collections.Generic;
using System.Linq;
using Books.Entities;
using Books.Repositories;
using NLog;

namespace Books.Services
{
	public class BookListService : IBookListService
	{
		private IBookListRepository _repository;
		private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

		public BookListService(IBookListRepository bookListRepository)
		{
			_repository = bookListRepository;
		}

		public void AddBook(Book book)
		{
			_repository.AddBook(book);
			_repository.SaveBookList();
			logger.Info($"Book with ISBN {book.Isbn} are added.");
		}

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

		public void RemoveBook(Book book)
		{
			_repository.RemoveBook(book);
			_repository.SaveBookList();
			logger.Info($"Book with ISBN {book.Isbn} are deleted.");
		}

		public void SortBooksByTag(IComparer<Book> comparer)
		{
			_repository.Books = _repository.Books.OrderBy(x => x, comparer).ToList();
			_repository.SaveBookList();
			logger.Info($"Books list was sorted.");
		}
	}
}
