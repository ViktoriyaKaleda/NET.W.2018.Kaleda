using NLog;
using UrlParser.DAL.Interface.Interfaces;

namespace UrlParser.DAL.Repositories
{
	public class NLogWrapper : ICustomLogger
	{
		private Logger _logger;

		public NLogWrapper(string loggerName)
		{
			_logger = LogManager.GetLogger(loggerName);
		}

		public void Debug(string msg)
		{
			_logger.Debug(msg);
		}

		public void Error(string msg)
		{
			_logger.Error(msg);
		}

		public void Info(string msg)
		{
			_logger.Info(msg);
		}

		public void Warn(string msg)
		{
			_logger.Warn(msg);
		}
	}
}
