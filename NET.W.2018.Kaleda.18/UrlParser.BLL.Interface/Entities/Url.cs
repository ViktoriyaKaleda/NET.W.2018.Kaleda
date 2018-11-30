using System.Collections.Generic;

namespace UrlParser.BLL.Interface.Entities
{
	public class Url
	{
		public string Scheme { get; set; }

		public string Host { get; set; }

		public List<string> Segments { get; set; }

		public Dictionary<string, string> Parameters { get; set; }

		public Url()
		{
			Segments = new List<string>();
			Parameters = new Dictionary<string, string>();
		}
	}
}
