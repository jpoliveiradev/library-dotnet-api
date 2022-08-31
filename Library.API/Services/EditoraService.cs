using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Library.API.Services {
    public class EditoraService : IEditoraService {

        private readonly IRepository _repo;
        public EditoraService(IRepository repository) {
            _repo = repository;
        }

        public Editoras EditoraCreate(Editoras model) {
            var nomeEditora = _repo.GetEditoraByNome(model.NomeEditora);

            if(nomeEditora != null) {
                return null;
            }

            _repo.Add<Editoras>(model);
            _repo.SaveChanges();
            return model;
        }
    }
}
