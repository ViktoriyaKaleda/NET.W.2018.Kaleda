using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AbstractBankAccount, BankAccount>();
			CreateMap<BankAccount, AbstractBankAccount>();
		}
	}
}
