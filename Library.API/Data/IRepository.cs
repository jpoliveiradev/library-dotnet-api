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
        Clientes[] GetAllClientesCount();
        Clientes GetClienteById(int clienteId);
        Clientes GetClienteByEmail(string email);
        Alugueis GetClienteByAluguel(int clienteId);

        //Editoras
        Task<PageList<Editoras>> GetAllEditorasAsync(PageParams pageParams);
        Editoras[] GetAllEditoras();
        Editoras GetEditoraById(int editoraId);
        Editoras GetEditoraByNome(string nome);
        Livros GetEditoraByLivro(int editoraId);

        //Livros
        Task<PageList<Livros>> GetAllLivrosAsync(PageParams pageParams);
        Livros[] GetAllLivros(bool includeEditora = false);
        Livros[] GetAllLivrosByEditoraId(int editoraId, bool includeEditora = false);
        Livros GetLivroById(int livroId, bool includeEditora = false);
        Livros GetLivroByNome(string nome);
        Alugueis GetLivroByAluguel(int livroId);

        //Alugueis
        Task<PageList<Alugueis>> GetAllAlugueisAsync(PageParams pageParams);
        Alugueis[] GetAllAlugueis();
        Alugueis GetAluguelById(int aluguelId);

        //Admins
        Task<PageList<Admins>> GetAllAdminsAsync(PageParams pageParams);
        Admins[] GetAllAdmins();
        Admins GetAdminById(int adminId);
        Admins GetAdminByEmail(string email);
        Admins GetAdminByUsername(string username);

    }
}
