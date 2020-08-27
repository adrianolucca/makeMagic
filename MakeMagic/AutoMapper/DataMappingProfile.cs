using AutoMapper;
using Modelo.Domain.Entities;
using Modelo.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeMagic.AutoMapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Personagem, PersonagemDTO>().ReverseMap();
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.id, map => map.MapFrom(m => m.id));
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.Name, map => map.MapFrom(m => m.Name));
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.Patronus, map => map.MapFrom(m => m.Patronus));
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.Role, map => map.MapFrom(m => m.Role));
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.School, map => map.MapFrom(m => m.School));
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.House, map => map.MapFrom(m => m.House));
            CreateMap<Personagem, PersonagemDTO>().ForMember(p => p.CreateAt, map => map.MapFrom(m => m.CreateAt));

        }
    }
}