using Library.API.Models;
using System;

namespace Library.API.V2.Dtos.LivroDto {
    public class LivroDto {
        public int Id { get; set; }

        public string NomeLivro { get; set; }

        public int EditoraId { get; set; }

        public Editoras Editora { get; set; }

        public string Autor { get; set; }

        public DateTime Lancamento { get; set; }

        public int Quantidade { get; set; }
        public int QuantAlugado { get; set; }
    }
}
