using System;
using UrlParser.BLL.Interface.Entities;

namespace UrlParser.BLL.Interface.Interfaces
{
	public interface IUrlParser
	{
		Url Parse(Uri uri);
	}
}
