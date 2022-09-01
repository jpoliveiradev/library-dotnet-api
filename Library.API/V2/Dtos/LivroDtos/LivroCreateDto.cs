using System;

namespace Library.API.V2.Dtos.LivroCreateDto {
    public class LivroCreateDto
    {

        public string NomeLivro { get; set; }

        public int EditoraId { get; set; }

        public string Autor { get; set; }

        public DateTime Lancamento { get; set; }

        public int Quantidade { get; set; }
    }
}
