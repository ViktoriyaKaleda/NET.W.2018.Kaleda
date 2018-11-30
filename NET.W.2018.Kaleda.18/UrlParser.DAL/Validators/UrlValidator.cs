using System;
using UrlParser.DAL.Interface.Interfaces;

namespace UrlParser.DAL.Validators
{
	public class UrlValidator : IValidator
	{
		public bool Validate(string url)
		{
			return Uri.IsWellFormedUriString(url, UriKind.Absolute);
		}
	}
}
