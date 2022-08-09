using System;

namespace Library.API.Models {
    public class Alugueis {

        public Alugueis() {

        }

        public Alugueis(int id, int livroId, int clienteId, DateTime dataAluguel, DateTime dataPrevisao, DateTime dataDevolucao) {
            Id = id;
            LivroId = livroId;
            ClienteId = clienteId;
            DataAluguel = dataAluguel;
            DataPrevisao = dataPrevisao;
            DataDevolucao = dataDevolucao;
        }

        public int Id { get; set; }

        public int LivroId { get; set; }

        public Livros Livro { get; set; }
        
        public int ClienteId { get; set; }

        public Clientes Cliente { get; set; }

        public DateTime DataAluguel { get; set; }

        public DateTime DataPrevisao { get; set; }

        public DateTime DataDevolucao { get; set; }

    }
}
