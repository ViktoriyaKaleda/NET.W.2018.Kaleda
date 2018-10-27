using Books.Entities;

namespace Books.Services
{
	public interface IBookListService
	{
		void AddBook(Book book);

		void RemoveBook(Book book);

		Book FindBookByTag(string tag);

		void SortBooksByTag();
	}
}
