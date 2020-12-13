using System;
using AutoMapper;
using Notnet_rgp.Dtos.Character;
using Notnet_rgp.Model;

namespace Notnet_rgp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacter>();
            CreateMap<AddCharacter, Character>();
        }
    }
}
