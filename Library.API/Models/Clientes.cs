using System.Collections.Generic;

namespace Library.API.Models {
    public class Clientes {

        public Clientes() {

        }

        public Clientes(int id, string nome, string endereco, string cidade, string email) {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Email = email;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Email { get; set; }

        public IEnumerable<Alugueis> Alugueis { get; set; }


    }
}
