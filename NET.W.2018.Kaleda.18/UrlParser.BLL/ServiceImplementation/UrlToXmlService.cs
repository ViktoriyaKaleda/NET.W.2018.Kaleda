using System.Linq;
using System.Xml.Linq;
using UrlParser.BLL.Interface.Entities;
using UrlParser.BLL.Interface.Interfaces;
using UrlParser.DAL.Interface.Interfaces;

namespace UrlParser.BLL.ServiceImplementation
{
	/// <summary>
	/// Class that parses URL addresses information from given data source 
	/// in XML format and returns XDocument result.
	/// </summary>
	public class UrlToXmlService : IUrlService<XDocument>
	{
		private IDataProvider _dataProvider;

		private IUrlParser _parser;

		public UrlToXmlService(IDataProvider dataProvider, IUrlParser parser)
		{
			_dataProvider = dataProvider;
			_parser = parser;
		}

		public XDocument Parse()
		{
			var sourceUrls = _dataProvider.GetUrlsData();

			var parsedUrls = sourceUrls.Select(uri => _parser.Parse(uri));

			var document = new XDocument();

			var urlAdresses = new XElement("urlAddresses");

			foreach (var url in parsedUrls)
			{
				urlAdresses.Add(CreateXmlUrlAdressNode(url));
			}

			document.Add(urlAdresses);

			return document;
		}

		private XElement CreateXmlUrlAdressNode(Url url)
		{
			// create url address element
			var urlAddress = new XElement("urlAddress");

			// add host element with attribute name
			urlAddress.Add(new XElement("host", new XAttribute("name", url.Host)));

			// add segments elements to url address element
			if (url.Segments.Any())
				urlAddress.Add(new XElement("uri", url.Segments.Select(s => new XElement("segment", s))));

			// add parameters elements to url address element
			if (url.Parameters.Any())
				urlAddress.Add(new XElement("parameters", url.Parameters.Select(
					p => new XElement("parameter", new XAttribute("key", p.Key), new XAttribute("value", p.Value)))));

			return urlAddress;
		}
	}
}
