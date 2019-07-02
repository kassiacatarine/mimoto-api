using AutoMapper;
using Mimoto.Application.ViewModels.Common;
using Mimoto.Domain.Common;

namespace Mimoto.Application.Mappers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserProfileViewModel>().ReverseMap();
        }
    }
}