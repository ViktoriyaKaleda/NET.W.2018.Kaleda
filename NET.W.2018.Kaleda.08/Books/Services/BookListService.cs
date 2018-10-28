using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Entities;
using Books.Repositories;

namespace Books.Services
{
	public class BookListService : IBookListService
	{
		private IBookListRepository _repository;

		public BookListService(IBookListRepository bookListRepository)
		{
			_repository = bookListRepository;
		}

		public void AddBook(Book book)
		{
			_repository.AddBook(book);
			_repository.SaveBookList();
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
		}

		public void SortBooksByTag()
		{
			throw new NotImplementedException();
		}
	}
}
