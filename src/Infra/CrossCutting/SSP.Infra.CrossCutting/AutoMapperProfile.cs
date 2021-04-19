using AutoMapper;
using SSP.Domain;
using SSP.Infra.Data.Entity;

namespace SSP.Infra.CrossCutting
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<UserDomain, UserEntity>().ReverseMap();
            CreateMap<ProfileDomain, ProfileEntity>().ReverseMap();
        }
    }
}