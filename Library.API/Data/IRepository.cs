using Library.API.Models;

namespace Library.API.Data {
    public interface IRepository  {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Clientes
        Clientes[] GetAllClientes();
        Clientes GetClienteById(int clienteId);

        //Editoras
        Editoras[] GetAllEditoras();
        Editoras GetEditoraById(int editoraId);

        //Livros
        Livros[] GetAllLivros(bool includeEditora = false);
        Livros[] GetAllLivrosByEditoraId(int editoraId, bool includeEditora = false);
        Livros[] GetAllLivrosByEditoraName();
        Livros GetLivroById(int livroId, bool includeEditora = false);

        //Alugueis
        Alugueis[] GetAllAlugueis();
       // Alugueis[] GetAllAlugueisByLivrosName();
       // Alugueis[] GetAllAlugueisByClientesName();
        Alugueis GetAluguelById(int aluguelId);

    }
}
