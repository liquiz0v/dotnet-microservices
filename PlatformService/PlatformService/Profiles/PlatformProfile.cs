using System.Collections.Generic;
using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            // Source -> Target
            
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformReadDto, Platform>();
            CreateMap<Platform, PlatformWriteDto>();
            CreateMap<PlatformWriteDto, Platform>();
        }
    }
}