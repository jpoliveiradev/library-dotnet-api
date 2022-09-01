
using System;

namespace Library.API.V2.Dtos.AluguelUpdateDto 
{
    public class AluguelUpdateDto
    {

       public int Id { get; set; }

        public int LivroId { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataAluguel { get; set; }

        public DateTime DataPrevisao { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
