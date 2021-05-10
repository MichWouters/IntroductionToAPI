using AutoMapper;
using MyFirstApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryOfOrigin))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(
                    src => src.Photos.FirstOrDefault(x => x.IsProfilePicture).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }
    }
}
