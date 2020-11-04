using AutoMapper;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Mapper.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, ProductStoreResponse>()
                .ForMember(pr => pr.Id, pr => pr.MapFrom(i => i.Id))
                .ForMember(pr => pr.Quantity, pr => pr.MapFrom(i => i.Quantity))
                .ForMember(pr => pr.Price, pr => pr.MapFrom(i => i.Price.ToString("0.00")))
                .ForMember(pr => pr.MeasureUnit, pr => pr.MapFrom(i => ((MeasureUnit)i.MeasureUnit).ToString()))
                .ForMember(pr => pr.Store, pr => pr.MapFrom(i => i.Store.Name))
                .ForMember(pr => pr.UrlImageProduct, pr => pr.MapFrom(i => i.Product.UrlImage))
                .ForMember(pr => pr.Product, pr => pr.MapFrom(i => i.Product.Name))
                .ForMember(pr => pr.Latitude, pr => pr.MapFrom(i => i.Store.Latitude))
                .ForMember(pr => pr.Longitude, pr => pr.MapFrom(i => i.Store.Longitude));
        }
    }
}
