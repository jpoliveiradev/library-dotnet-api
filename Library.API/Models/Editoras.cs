using System.Collections.Generic;

namespace Library.API.Models {
    public class Editoras {

        public Editoras() {

        }

        public Editoras(int id, string nomeEditora, string cidade) {
            Id = id;
            NomeEditora = nomeEditora;
            Cidade = cidade;
        }

        public int Id { get; set; }

        public string NomeEditora { get; set; }

        public string Cidade { get; set; }

        public IEnumerable<Livros> Livros { get; set; }
    }
}
