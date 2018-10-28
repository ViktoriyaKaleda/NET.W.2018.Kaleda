using Books.Entities;
using System.Collections.Generic;

namespace Books.Services
{
	public interface IBookListService
	{
		void AddBook(Book book);

		void RemoveBook(Book book);

		List<Book> FindBooksByTag(string tag);

		void SortBooksByTag();
	}
}
