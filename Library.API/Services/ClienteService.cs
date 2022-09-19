using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;

namespace Library.API.Services {

    public class ClienteService : IClienteService {

        private readonly IRepository _repo;
        public ClienteService(IRepository repository) {
            _repo = repository;
        }

        public Clientes ClienteCreate(Clientes model) {
            var email = _repo.GetClienteByEmail(model.Email);

            if (email != null) {
                return null;
            }
            else {
                _repo.Add<Clientes>(model);
                _repo.SaveChanges();
                return model;
            }

        }

        public Clientes ClienteUpdate(Clientes model) {
            var clientePorId = _repo.GetClienteById(model.Id);
            if (clientePorId == null) return null;

            var clientePorEmail = _repo.GetClienteByEmail(model.Email);
            if (clientePorEmail == null) {
                clientePorId.NomeUsuario = model.NomeUsuario;
                clientePorId.Endereco = model.Endereco;
                clientePorId.Cidade = model.Cidade;
                clientePorId.Email = model.Email;
            }
            else {
                if (clientePorId.Id == clientePorEmail.Id) {
                    clientePorId.NomeUsuario = model.NomeUsuario;
                    clientePorId.Endereco = model.Endereco;
                    clientePorId.Cidade = model.Cidade;
                }
                else {
                    return null;
                }
            }
            _repo.Update<Clientes>(clientePorId);
            _repo.SaveChanges();
            return model;
        }
    }
}
