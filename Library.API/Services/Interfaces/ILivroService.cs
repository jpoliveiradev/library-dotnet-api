using Library.API.Models;

namespace Library.API.Services.Interfaces {
    public interface ILivroService {

        Livros LivroCreate(Livros model);
        Livros LivroUpdate(Livros model);

    }
}
