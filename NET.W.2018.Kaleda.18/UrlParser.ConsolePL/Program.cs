using System.Xml.Linq;
using Ninject;
using DependencyResolver;
using UrlParser.BLL.Interface.Interfaces;

namespace UrlParser.ConsolePL
{
	class Program
	{
		private static readonly IKernel _resolver;

		static Program()
		{
			_resolver = new StandardKernel();
			_resolver.ConfigurateResolver();
		}

		static void Main(string[] args)
		{
			var urlToXmlService = _resolver.Get<IUrlService<XDocument>>();

			var resultXmlDocument = urlToXmlService.Parse();

			resultXmlDocument.Save("result.xml");
		}
	}
}
