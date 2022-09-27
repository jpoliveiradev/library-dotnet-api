using System;

namespace Library.API.Models {
    public class Admins {

        public Admins() {

        }

        public Admins(int id, string nomeAdmin, string email, string endereco, string userName, string password) {
            Id = id;
            NomeAdmin = nomeAdmin;
            Email = email;
            Endereco = endereco;
            UserName = userName;
            Password = password;
        }

        public int Id { get; set; }
        public string NomeAdmin { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


    }
}
