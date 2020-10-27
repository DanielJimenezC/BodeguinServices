using AutoMapper;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Mapper.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreResponse>()
                .ForMember(sr => sr.Id, sr => sr.MapFrom(s => s.Id))
                .ForMember(sr => sr.Name, sr => sr.MapFrom(s => s.Name))
                .ForMember(sr => sr.Direction, sr => sr.MapFrom(s => s.Direction))
                .ForMember(sr => sr.Latitude, sr => sr.MapFrom(s => s.Latitude))
                .ForMember(sr => sr.Longitude, sr => sr.MapFrom(s => s.Longitude));
        }
    }
}
