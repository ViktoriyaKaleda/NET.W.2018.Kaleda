using System;
using System.Linq;
using System.Web;
using UrlParser.BLL.Interface.Entities;
using UrlParser.BLL.Interface.Interfaces;

namespace UrlParser.BLL.ServiceImplementation
{
	public class UrlParser : IUrlParser
	{
		public Url Parse(Uri url)
		{
			Url result = new Url
			{
				Scheme = url.Scheme,
				Host = url.Host,
				Segments = url.Segments.ToList()
			};

			result.Segments.Remove("/");

			var parameters = HttpUtility.ParseQueryString(url.Query);

			foreach (string item in parameters.AllKeys)
			{
				result.Parameters.Add(item, parameters[item]);
			}

			return result;
		}
	}
}
