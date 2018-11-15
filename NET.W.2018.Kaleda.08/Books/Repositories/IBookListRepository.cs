using Books.Entities;
using System.Collections.Generic;

namespace Books.Repositories
{
	/// <summary>
	/// Interface that provides API for books repository.
	/// </summary>
	public interface IBookListRepository
	{ 
		List<Book> Books { get; set; }

		void AddBook(Book book);

		void UpdateBook(Book book);

		void RemoveBook(Book book);

		void SaveBookList();

		void ClearBookList();
	}
}
