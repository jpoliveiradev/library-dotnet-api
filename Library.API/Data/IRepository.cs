using Library.API.Models;

namespace Library.API.Data {
    public interface IRepository  {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Clientes
        Clientes[] GetAllClientes();
        Clientes GetClienteById();
        
        //Editoras
        Editoras[] GetAllEditoras();
        Editoras GetEditoraById();
        
        //Livros
        Livros[] GetAllLivros();
        Livros[] GetAllLivrosByEditoraId();
        Livros GetLivroById();
        
        //Alugueis
       // Alugueis[] GetAllAlugueis();
        //Alugueis GetAluguel();

    }
}
