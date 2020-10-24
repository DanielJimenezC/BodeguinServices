using AutoMapper;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Mapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponse>()
                .ForMember(cr => cr.Id, cr => cr.MapFrom(c => c.Id))
                .ForMember(cr => cr.Name, cr => cr.MapFrom(c => c.Name))
                .ForMember(cr => cr.UrlImage, cr => cr.MapFrom(c => c.UrlImage))
                .ForMember(cr => cr.NumProducts, cr => cr.MapFrom(c => c.Products.Count));
        }
    }
}
