using System;
using System.Collections.Generic;

namespace UrlParser.DAL.Interface.Interfaces
{
	public interface IDataProvider
	{
		IEnumerable<Uri> GetUrlsData();
	}
}
