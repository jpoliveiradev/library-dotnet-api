using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Library.API.Services {
    public class EditoraService : IEditoraService {

        private readonly IRepository _repo;
        public EditoraService(IRepository repository) {
            _repo = repository;
        }

        public Editoras EditoraCreate(Editoras model) {
            var nomeEditora = _repo.GetEditoraByNome(model.NomeEditora);

            if (nomeEditora != null) {
                return null;
            }

            _repo.Add<Editoras>(model);
            _repo.SaveChanges();
            return model;
        }

        public Editoras EditoraUpdate(Editoras model) {
            var editoraPorId = _repo.GetEditoraById(model.Id);
            if (editoraPorId == null) return null;

            var editoraPorNome = _repo.GetEditoraByNome(model.NomeEditora);
            if (editoraPorNome == null) {
                editoraPorId.NomeEditora = model.NomeEditora;
                editoraPorId.Cidade = model.Cidade;
            }
            else {
                if (editoraPorId.Id == editoraPorNome.Id) {
                    editoraPorId.Cidade = model.Cidade;
                }
                else {
                    return null;
                }
            }
            _repo.Update<Editoras>(editoraPorId);
            _repo.SaveChanges();
            return model;
        }
    }
}
