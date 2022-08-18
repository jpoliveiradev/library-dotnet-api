﻿using Library.API.Models;
using Library.API.V1.Dtos;
using AutoMapper;

namespace Library.API.V1.Profiles
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {

            CreateMap<Clientes, ClienteDto>(

               //.ForMember(
               //    dest => dest.Id,
               //    opt => opt.MapFrom(src => src.Id)
               );

            CreateMap<ClienteDto, Clientes>();
            CreateMap<Clientes, ClienteRegistrarDto>().ReverseMap();




        }
    }
}