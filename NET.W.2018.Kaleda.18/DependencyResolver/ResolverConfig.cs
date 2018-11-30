using System.Xml.Linq;
using Ninject;
using UrlParser.BLL.Interface.Interfaces;
using UrlParser.BLL.ServiceImplementation;
using UrlParser.DAL.Interface.Interfaces;
using UrlParser.DAL.Repositories;
using UrlParser.DAL.Validators;

namespace DependencyResolver
{
	public static class ResolverConfig
	{
		public static void ConfigurateResolver(this IKernel kernel)
		{
			kernel.Bind<IValidator>().To<UrlValidator>();

			kernel.Bind<ICustomLogger>().To<NLogWrapper>();

			kernel.Bind<IDataProvider>()
				.To<TextFileDataProvider>()
				.WithConstructorArgument("path", ctx => "source.txt")
				.WithConstructorArgument("validator", ctx => ctx.Kernel.Get<IValidator>())
				.WithConstructorArgument("logger", ctx => null);

			kernel.Bind<IUrlParser>().To<UrlParser.BLL.ServiceImplementation.UrlParser>();

			kernel.Bind<IUrlService<XDocument>>()
				.To<UrlToXmlService>()
				.WithConstructorArgument("dataProvider", ctx => ctx.Kernel.Get<IDataProvider>())
				.WithConstructorArgument("parser", ctx => ctx.Kernel.Get<IUrlParser>());
		}
	}
}
