using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AbstractBankAccount, BankAccount>()
				.ForMember(m => m.Owner, opt => opt.MapFrom(src => src.Owner));

			CreateMap<BankAccount, AbstractBankAccount>().ForMember(m => m.Owner, opt => opt.MapFrom(src => src.Owner))
				.ForMember(m => m.Owner, opt => opt.MapFrom(src => src.Owner));

			CreateMap<Interface.Entities.AccountOwner, DAL.Interface.DTO.AccountOwner>();
			CreateMap<Interface.Entities.BankAccountType, DAL.Interface.DTO.BankAccountType>();
		}
	}
}
