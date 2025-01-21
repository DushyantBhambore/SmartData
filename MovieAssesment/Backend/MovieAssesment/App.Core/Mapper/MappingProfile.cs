using App.Core.Dto;
using AutoMapper;
using Doamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<registerDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<loginDto,User>()
                .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.UserName))
                .ForMember(dest=>dest.Password,opt=>opt.MapFrom(src=>src.Password));
        
            CreateMap<RoleDto ,Role>()
                .ForMember(dest=>dest.RoleId,opt=>opt.MapFrom(src=>src.RoleId))
                .ForMember(dest=>dest.RoleName,opt=>opt.MapFrom(src=>src.RoleName));

            CreateMap<MovieDetailsDto, MovieDetails>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.MoviTitle, opt => opt.MapFrom(src => src.MoviTitle))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));



        }
    }
}
