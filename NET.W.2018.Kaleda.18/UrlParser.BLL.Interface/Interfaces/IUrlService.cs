namespace UrlParser.BLL.Interface.Interfaces
{
	public interface IUrlService<out TResult>
	{
		TResult Parse();
	}
}
