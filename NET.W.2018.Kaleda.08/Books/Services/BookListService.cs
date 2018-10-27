using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Entities;
using Books.Repositories;

namespace Books.Services
{
	class BookListService : IBookListService
	{
		private IBookListRepository _repository;

		public BookListService(IBookListRepository bookListRepository)
		{
			_repository = bookListRepository;
		}

		public void AddBook(Book book)
		{
			throw new NotImplementedException();
		}

		public Book FindBookByTag(string tag)
		{
			throw new NotImplementedException();
		}

		public void RemoveBook(Book book)
		{
			throw new NotImplementedException();
		}

		public void SortBooksByTag()
		{
			throw new NotImplementedException();
		}
	}
}
