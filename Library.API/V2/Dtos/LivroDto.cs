using Library.API.Models;
using System;

namespace Library.API.V2.Dtos {
    public class LivroDto {

        public string NomeLivro { get; set; }

        public int EditoraId { get; set; }

        public string Autor { get; set; }

        public DateTime Lancamento { get; set; }

        public int Quantidade { get; set; }
    }
}
