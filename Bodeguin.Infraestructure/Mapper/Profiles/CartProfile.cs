using AutoMapper;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Mapper.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<DetailRequest, Detail>()
                .ForMember(d => d.InventoryId, d => d.MapFrom(dr => dr.InventoryId))
                .ForMember(d => d.Quantity, d => d.MapFrom(dr => dr.Quantity))
                .ForMember(d => d.Price, d => d.MapFrom(dr => dr.Price));

            CreateMap<ShopCartRequest, Voucher>()
                .ForMember(v => v.PaymentTypeId, v => v.MapFrom(sr => sr.PaymentId))
                .ForMember(v => v.UserId, v => v.MapFrom(sr => sr.UserId));
        }
    }
}
