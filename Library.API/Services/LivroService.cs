using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;

namespace Library.API.Services {
    public class LivroService : ILivroService {
        private readonly IRepository _repo;

        public LivroService(IRepository repository) {
            _repo = repository;
        }
        public Livros LivroCreate(Livros model) {
            var nomeLivro = _repo.GetLivroByNome(model.NomeLivro);

            if (nomeLivro != null) {
                return null;
            }

            _repo.Add<Livros>(model);
            _repo.SaveChanges();
            return model;
        }
    }
}
