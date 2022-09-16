using Library.API.Helpers;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Data {
    public class Repository : IRepository {
        private readonly DataContext _context;

        public Repository(DataContext context) {
            _context = context;
        }

        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }
        public bool SaveChanges() {
            return (_context.SaveChanges() > 0);
        }

        // Clientes
        public async Task<PageList<Clientes>> GetAllClientesAsync(PageParams pageParams) {
            IQueryable<Clientes> query = _context.Clientes;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            if (!string.IsNullOrEmpty(pageParams.NomeUsuario)) {
                query = query.Where(c => c.NomeUsuario.ToUpper()
                                                      .Contains(pageParams.NomeUsuario.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Email)) {
                query = query.Where(c => c.Email.ToUpper()
                                                      .Contains(pageParams.Email.ToUpper()));
            }


            return await PageList<Clientes>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }


        public Clientes[] GetAllClientes() {
            IQueryable<Clientes> query = _context.Clientes;

            query = query.AsNoTracking().OrderBy(c => c.Id);
            return query.ToArray();
        }
        public Clientes[] GetAllClientesCount() {
            IQueryable<Clientes> query = _context.Clientes;
             query = query.Where(c => c.Id == c.Id);
            query.Count();
            return query.ToArray();
        }

        public Clientes GetClienteById(int clienteId) {
            IQueryable<Clientes> query = _context.Clientes;

            query = query.AsNoTracking()
                            .OrderBy(c => c.Id)
                            .Where(cliente => cliente.Id == clienteId);
            return query.FirstOrDefault();
        }
        public Clientes GetClienteByEmail(string email) {
            IQueryable<Clientes> query = _context.Clientes;
            query = query.Where(c => c.Email == email);
            return query.FirstOrDefault();
        }

        public Alugueis GetClienteByAluguel(int clienteId) {
            IQueryable<Alugueis> query = _context.Alugueis;

            query = query.AsNoTracking()
                .OrderBy(c => c.Id)
                .Where(c => c.ClienteId == clienteId);
            return query.FirstOrDefault();
        }

        // Editoras
        public async Task<PageList<Editoras>> GetAllEditorasAsync(PageParams pageParams) {
            IQueryable<Editoras> query = _context.Editoras;

            query = query.AsNoTracking().OrderBy(ed => ed.Id);

            if (!string.IsNullOrEmpty(pageParams.NomeEditora)) {
                query = query.Where(ed => ed.NomeEditora.ToUpper()
                                                      .Contains(pageParams.NomeEditora.ToUpper()));
            }

            return await PageList<Editoras>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public Editoras[] GetAllEditoras() {
            IQueryable<Editoras> query = _context.Editoras;

            query = query.AsNoTracking().OrderBy(ed => ed.Id);
            return query.ToArray();
        }
        public Editoras GetEditoraById(int editoraId) {
            IQueryable<Editoras> query = _context.Editoras;

            query = query.AsNoTracking()
                .OrderBy(ed => ed.Id)
                .Where(editora => editora.Id == editoraId);

            return query.FirstOrDefault();
        }
        public Editoras GetEditoraByNome(string nome) {
            IQueryable<Editoras> query = _context.Editoras;
            query = query.Where(e => e.NomeEditora == nome);
            return query.FirstOrDefault();
        }
        public Livros GetEditoraByLivro(int editoraId) {
            IQueryable<Livros> query = _context.Livros;

            query = query.AsNoTracking().OrderBy(l => l.Id)
                                        .Where(l => l.EditoraId == editoraId);

            return query.FirstOrDefault();
        }

        // Livros
        public async Task<PageList<Livros>> GetAllLivrosAsync(PageParams pageParams) {
            IQueryable<Livros> query = _context.Livros;



            query = query.Include(l => l.Editora);


            query = query.AsNoTracking().OrderBy(l => l.Id);

            if (!string.IsNullOrEmpty(pageParams.NomeLivro)) {
                query = query.Where(l => l.NomeLivro.ToUpper()
                                                      .Contains(pageParams.NomeLivro.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Autor)) {
                query = query.Where(l => l.Autor.ToUpper()
                                                      .Contains(pageParams.Autor.ToUpper()));
            }

            return await PageList<Livros>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public Livros[] GetAllLivros(bool includeEditora = false) {
            IQueryable<Livros> query = _context.Livros;


            if (includeEditora) {
                query = query.Include(l => l.Editora);
            }

            query = query.AsNoTracking().OrderBy(l => l.Id);

            return query.ToArray();
        }
        public Livros GetLivroById(int livroId, bool includeEditora = false) {
            IQueryable<Livros> query = _context.Livros;


            if (includeEditora) {
                query = query.Include(l => l.Editora);
            }

            query = query.AsNoTracking()
                .OrderBy(l => l.Id)
                .Where(livro => livro.Id == livroId);

            return query.FirstOrDefault();
        }

        public Livros[] GetAllLivrosByEditoraId(int editoraId, bool includeEditora = false) {
            IQueryable<Livros> query = _context.Livros;


            if (includeEditora) {
                query = query.Include(l => l.Editora);
            }


            query = query.AsNoTracking()
                .OrderBy(l => l.Id)
                .Where(Editoras => Editoras.Id == editoraId);

            return query.ToArray();
        }
        public Livros GetLivroByNome(string nome) {
            IQueryable<Livros> query = _context.Livros;
            query = query.Where(e => e.NomeLivro == nome);
            return query.FirstOrDefault();
        }
        public Alugueis GetLivroByAluguel(int livroId) {
            IQueryable<Alugueis> query = _context.Alugueis;

            query = query.AsNoTracking().OrderBy(l => l.Id)
                                        .Where(l => l.LivroId == livroId);

            return query.FirstOrDefault();
        }



        //Alugueis
        public async Task<PageList<Alugueis>> GetAllAlugueisAsync(PageParams pageParams) {
            IQueryable<Alugueis> query = _context.Alugueis;



            query = query.Include(al => al.Livro);
            query = query.Include(al => al.Cliente);

            query = query.AsNoTracking().OrderBy(al => al.Id);

            return await PageList<Alugueis>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public Alugueis[] GetAllAlugueis() {
            IQueryable<Alugueis> query = _context.Alugueis;



            query = query.Include(al => al.Livro);
            query = query.Include(al => al.Cliente);

            query = query.AsNoTracking().OrderBy(al => al.Id);

            return query.ToArray();
        }
        public Alugueis GetAluguelById(int aluguelId) {
            IQueryable<Alugueis> query = _context.Alugueis;



            //  query = query.Include(al => al.Livro);
            query = query.Include(al => al.Cliente);


            query = query.AsNoTracking()
                .OrderBy(al => al.Id)
                .Where(aluguel => aluguel.Id == aluguelId);

            return query.FirstOrDefault();
        }
    }
}
