namespace Library.API.Models {
    public class Alugueis {

        public Alugueis() {

        }

        public Alugueis(int id, string livroId, int clienteId, string dataAluguel, string dataPrevisao, string dataDevolucao) {
            Id = id;
            LivroId = livroId;
            ClienteId = clienteId;
            DataAluguel = dataAluguel;
            DataPrevisao = dataPrevisao;
            DataDevolucao = dataDevolucao;
        }

        public int Id { get; set; }

        public string LivroId { get; set; }

        public Livros Livros { get; set; }
        
        public int ClienteId { get; set; }

        public Clientes Clientes { get; set; }

        public string DataAluguel { get; set; }

        public string DataPrevisao { get; set; }

        public string DataDevolucao { get; set; }

    }
}
