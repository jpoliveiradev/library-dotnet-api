using System;

namespace Library.API.V2.Dtos.AluguelDto
{
    public class AluguelDto
    {


        public int LivroId { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataAluguel { get; set; }

        public DateTime DataPrevisao { get; set; }
    }
}
