using Library.API.Models;
using Library.API.V2.Dtos;
using AutoMapper;

namespace Library.API.V2.Profiles {
    public class LibraryProfile : Profile {
        public LibraryProfile() {

            CreateMap<Clientes, ClienteDto>().ReverseMap();
            CreateMap<Clientes, ClienteRegistrarDto>().ReverseMap();
            CreateMap<Editoras, EditoraDto>().ReverseMap();
            CreateMap<Livros, LivroDto>().ReverseMap();
            CreateMap<Alugueis, AluguelDto>().ReverseMap();
            CreateMap<Alugueis, AluguelDtoUpdate>().ReverseMap();

        }
    }
}
