using System.Collections.Generic;

namespace Library.API.Models {
    public class Editoras {

        public Editoras() {

        }

        public Editoras(int id, string nome_Editora, string cidade) {
            Id = id;
            Nome_Editora = nome_Editora;
            Cidade = cidade;
        }

        public int Id { get; set; }

        public string Nome_Editora { get; set; }

        public string Cidade { get; set; }

        public IEnumerable<Livros> Livros { get; set; }
    }
}
