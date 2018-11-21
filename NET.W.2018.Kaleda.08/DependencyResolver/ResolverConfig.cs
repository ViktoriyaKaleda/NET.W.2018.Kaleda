using BLL.Interface.Interfaces;
using BLL.Interface.Services;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
	public static class ResolverConfig
	{
		public static void ConfigurateResolver(this IKernel kernel)
		{
			kernel.Bind<IBankAccountService>().To<BankAccountService>();
			kernel.Bind<INumberGenerator>().To<NumberGenerator>();

			kernel.Bind<IBankAccountRepository>().To<BankAccountRepository>();
		}
	}
}
