using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;

namespace Library.API.Services {

    public class ClienteService : IClienteService {

        private readonly IRepository _clienteRepo;
        public ClienteService(IRepository repository) {
            _clienteRepo = repository;
        }

        public Clientes ClienteCreate(Clientes model) {
            var email = _clienteRepo.GetClienteByEmail(model.Email);

            if (email != null) {
                return null;
            }
            else {

                _clienteRepo.Add<Clientes>(model);
                _clienteRepo.SaveChanges();
                return model;
            }

        }

        public Clientes ClienteUpdate(Clientes model) {
            var email = _clienteRepo.GetClienteByEmail(model.Email);

            if (email != null) {
                return null;
            }
            else {

                _clienteRepo.Update<Clientes>(model);
                _clienteRepo.SaveChanges();
                return model;
            }
        }
    }
}
