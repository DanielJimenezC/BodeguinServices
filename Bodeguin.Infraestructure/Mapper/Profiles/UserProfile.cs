using AutoMapper;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Security.Encript;
using Bodeguin.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Infraestructure.Mapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoginResponse>()
                .ForMember(u => u.Id, l => l.MapFrom(u => u.Id))
                .ForMember(u => u.Name, l => l.MapFrom(u => u.Name))
                .ForMember(u => u.FirstLastName, l => l.MapFrom(u => u.FirstLastName))
                .ForMember(u => u.SecondLastName, l => l.MapFrom(u => u.SecondLastName))
                .ForMember(u => u.Direction, l => l.MapFrom(u => u.Direction))
                .ForMember(u => u.Dni, l => l.MapFrom(u => u.Dni))
                .ForMember(u => u.Email, l => l.MapFrom(u => u.Email))
                .ForMember(u => u.Password, l => l.MapFrom(u => Encript.DesencriptText(u.Password)))
                .ForMember(u => u.Active, l => l.MapFrom(u => u.IsActive))
                .ForMember(u => u.Admin, l => l.MapFrom(u => u.IsAdmin));

            CreateMap<SignUpRequest, User>()
                .ForMember(u => u.Email, u => u.MapFrom(s => s.Email))
                .ForMember(u => u.Password, u => u.MapFrom(s => Encript.EncriptText(s.Password)))
                .ForMember(u => u.Name, u => u.MapFrom(s => s.Name))
                .ForMember(u => u.FirstLastName, u => u.MapFrom(s => s.FirstLastName))
                .ForMember(u => u.SecondLastName, u => u.MapFrom(s => s.SecondLastName));
        }
    }
}
