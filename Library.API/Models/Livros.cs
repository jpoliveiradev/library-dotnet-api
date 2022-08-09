using System.Collections.Generic;

namespace Library.API.Models {
    public class Livros {
        public Livros() {

        }

        public Livros(int id, string nomeLivro, int editoraId, string autor, int lancamento) {
            Id = id;
            NomeLivro = nomeLivro;
            EditoraId = editoraId;
            Autor = autor;
            Lancamento = lancamento;

        }

        public int Id { get; set; }

        public string NomeLivro { get; set; }

        public int EditoraId { get; set; }

        public Editoras Editora { get; set; }

        public string Autor { get; set; }

        public int Lancamento { get; set; }

        



    }
}
