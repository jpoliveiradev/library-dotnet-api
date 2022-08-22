using Library.API.Helpers;
using Library.API.Models;
using System.Threading.Tasks;

namespace Library.API.Data {
    public interface IRepository {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Clientes
        Task<PageList<Clientes>> GetAllClientesAsync(PageParams pageParams);
        Clientes[] GetAllClientes();
        Clientes GetClienteById(int clienteId);

        //Editoras
        Task<PageList<Editoras>> GetAllEditorasAsync(PageParams pageParams);
        Editoras[] GetAllEditoras();
        Editoras GetEditoraById(int editoraId);

        //Livros
        Task<PageList<Livros>> GetAllLivrosAsync(PageParams pageParams, bool includeEditora = false);
        Livros[] GetAllLivros(bool includeEditora = false);
        Livros[] GetAllLivrosByEditoraId(int editoraId, bool includeEditora = false);
        Livros GetLivroById(int livroId, bool includeEditora = false);

        //Alugueis
        Task<PageList<Alugueis>> GetAllAlugueisAsync(PageParams pageParams);
        Alugueis[] GetAllAlugueis();
        Alugueis GetAluguelById(int aluguelId);

    }
}
