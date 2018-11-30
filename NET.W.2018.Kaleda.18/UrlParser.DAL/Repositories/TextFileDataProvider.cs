using System;
using System.Collections.Generic;
using System.IO;
using UrlParser.DAL.Interface.Interfaces;
using UrlParser.DAL.Validators;

namespace UrlParser.DAL.Repositories
{
	public class TextFileDataProvider : IDataProvider
	{
		private string _filePath;

		private IValidator _validator;

		private ICustomLogger _logger;

		public TextFileDataProvider(string path, IValidator validator, ICustomLogger logger)
		{
			if (!File.Exists(path))
				throw new ArgumentException("File is not exists.", nameof(path));

			if (validator == null)
				_validator = new UrlValidator();

			if (logger == null)
				_logger = new NLogWrapper("NLog");

			_filePath = path;
			_validator = validator;
		}

		public IEnumerable<Uri> GetUrlsData()
		{
			IEnumerable<string> urls = File.ReadLines(_filePath);

			var result = new List<Uri>();

			foreach (var item in urls)
			{
				if (_validator.Validate(item))
					result.Add(new Uri(item));
				else
					_logger.Warn($"Invalid url was taken: {item}");					
			}

			return result;
		}
	}
}
