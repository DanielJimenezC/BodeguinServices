using AutoMapper;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Mapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(pr => pr.Id, pr => pr.MapFrom(p => p.Id))
                .ForMember(pr => pr.Name, pr => pr.MapFrom(p => p.Name))
                .ForMember(pr => pr.Description, pr => pr.MapFrom(p => p.Description))
                .ForMember(pr => pr.UrlImage, pr => pr.MapFrom(p => p.UrlImage))
                .ForMember(pr => pr.NumStore, pr => pr.MapFrom(p => p.Inventories.Count));
        }
    }
}
