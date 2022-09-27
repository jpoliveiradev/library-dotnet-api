using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;

namespace Library.API.Services {

    public class AdminService : IAdminService {

        private readonly IRepository _repo;
        public AdminService(IRepository repository) {
            _repo = repository;
        }

        public Admins AdminCreate(Admins model) {
            var email = _repo.GetAdminByEmail(model.Email);
            var username = _repo.GetAdminByUsername(model.UserName);

            if (email != null || username != null) {
                return null;
            }

            else {
                _repo.Add<Admins>(model);
                _repo.SaveChanges();
                return model;
            }

        }

        public Admins AdminUpdate(Admins model) {
            var adminPorId = _repo.GetAdminById(model.Id);
            if (adminPorId == null) return null;

            var adminPorEmail = _repo.GetAdminByEmail(model.Email);
            var adminPorUsername = _repo.GetAdminByUsername(model.UserName);

            if (adminPorEmail == null && adminPorUsername == null) {
                adminPorId.NomeAdmin = model.NomeAdmin;
                adminPorId.Email = model.Email;
                adminPorId.Endereco = model.Endereco;
                adminPorId.UserName = model.UserName;
                adminPorId.Password = model.Password;
            }
            else {
                if (adminPorEmail != null && adminPorId.Id == adminPorEmail.Id) {
                    adminPorId.NomeAdmin = model.NomeAdmin;
                    adminPorId.Endereco = model.Endereco;
                    adminPorId.UserName = model.UserName;
                    adminPorId.Password = model.Password;
                }
                else if (adminPorUsername != null && adminPorId.Id == adminPorUsername.Id) {
                    adminPorId.NomeAdmin = model.NomeAdmin;
                    adminPorId.Email = model.Email;
                    adminPorId.Endereco = model.Endereco;
                    adminPorId.Password = model.Password;
                }

                else {
                    return null;
                }
            }
            _repo.Update<Admins>(adminPorId);
            _repo.SaveChanges();
            return model;
        }
    }
}