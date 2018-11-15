using Books.Entities;
using System.Collections.Generic;

namespace Books.Services
{
	/// <summary>
	/// Interface that provides API of service for managing books.
	/// </summary>
	public interface IBookListService
	{
		void AddBook(Book book);

		void RemoveBook(Book book);

		List<Book> FindBooksByTag(string tag);

		void SortBooksByTag(IComparer<Book> comparer);
	}
}
