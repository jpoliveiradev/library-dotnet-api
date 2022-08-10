using System.Collections.Generic;

namespace Library.API.Models {
    public class Clientes {

        public Clientes() {

        }

        public Clientes(int id, string nomeUsuario, string endereco, string cidade, string email) {
            Id = id;
            NomeUsuario = nomeUsuario;
            Endereco = endereco;
            Cidade = cidade;
            Email = email;
        }

        public int Id { get; set; }

        public string NomeUsuario { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Email { get; set; }


    }
}
