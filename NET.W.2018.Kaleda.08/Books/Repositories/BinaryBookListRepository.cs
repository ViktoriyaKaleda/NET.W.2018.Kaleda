using System;
using System.Collections.Generic;
using Books.Entities;

namespace Books.Repositories
{
	public class BinaryBookListRepository : IBookListRepository
	{
		public List<Book> Books { get; set; }

		public void AddBook(Book book)
		{
			throw new NotImplementedException();
		}

		public void ClearBookList()
		{
			throw new NotImplementedException();
		}

		public void RemoveBook(Book book)
		{
			throw new NotImplementedException();
		}

		public void SaveBookList(List<Book> books)
		{
			throw new NotImplementedException();
		}

		public void UpdateBook(Book book)
		{
			throw new NotImplementedException();
		}
	}
}
