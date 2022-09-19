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

        public Livros LivroUpdate(Livros model) {
            var livroPorId = _repo.GetLivroById(model.Id);
            if (livroPorId == null) return null;

            var livroPorNome = _repo.GetLivroByNome(model.NomeLivro);
            if (livroPorNome == null) {
                livroPorId.NomeLivro = model.NomeLivro;
                livroPorId.EditoraId = model.EditoraId;
                livroPorId.Autor = model.Autor;
                livroPorId.Lancamento = model.Lancamento;
                livroPorId.Quantidade = model.Quantidade;
            }
            else {
                if (livroPorId.Id == livroPorNome.Id) {
                    livroPorId.EditoraId = model.EditoraId;
                    livroPorId.Autor = model.Autor;
                    livroPorId.Lancamento = model.Lancamento;
                    livroPorId.Quantidade = model.Quantidade;
                }
                else {
                    return null;
                }
            }
            _repo.Update<Livros>(livroPorId);
            _repo.SaveChanges();
            return model;
        }
    }
}

