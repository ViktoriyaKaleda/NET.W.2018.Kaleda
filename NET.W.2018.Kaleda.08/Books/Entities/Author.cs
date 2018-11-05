namespace Books.Entities
{
	/// <summary>
	/// Class that contains information about a book author.
	/// </summary>
	public class Author
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}
	}
}
