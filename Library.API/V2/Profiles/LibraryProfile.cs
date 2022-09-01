using Library.API.Models;
using AutoMapper;
using Library.API.V2.Dtos.AluguelDto;
using Library.API.V2.Dtos.EditoraDto;
using Library.API.V2.Dtos.LivroDto;
using Library.API.V2.Dtos.ClienteDto;
using Library.API.V2.Dtos.AluguelUpdateDto;
using Library.API.V2.Dtos.ClienteCreateDto;
using Library.API.V2.Dtos.EditoraDtos;
using Library.API.V2.Dtos.LivroCreateDto;

namespace Library.API.V2.Profiles
{
    public class LibraryProfile : Profile {
        public LibraryProfile() {

            CreateMap<Clientes, ClienteDto>().ReverseMap();
            CreateMap<Clientes, ClienteCreateDto>().ReverseMap();
            CreateMap<Editoras, EditoraDto>().ReverseMap();
            CreateMap<Editoras, EditoraCreateDto>().ReverseMap();
            CreateMap<Livros, LivroDto>().ReverseMap();
            CreateMap<Livros, LivroCreateDto>().ReverseMap();
            CreateMap<Alugueis, AluguelDto>().ReverseMap();
            CreateMap<Alugueis, AluguelUpdateDto>().ReverseMap();

        }
    }
}
