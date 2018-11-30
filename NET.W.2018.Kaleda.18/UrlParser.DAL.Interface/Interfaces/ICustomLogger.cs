namespace UrlParser.DAL.Interface.Interfaces
{
	public interface ICustomLogger
	{
		void Info(string msg);
		void Debug(string msg);
		void Warn(string msg);		
		void Error(string msg);		
	}
}
