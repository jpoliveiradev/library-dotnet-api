using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public Clientes[] GetAllClientes() {
            IQueryable<Clientes> query = _context.Clientes;

            query = query.AsNoTracking().OrderBy(c => c.Id);
            return query.ToArray();
        }
        public Clientes GetClienteById(int clienteId) {
            IQueryable<Clientes> query = _context.Clientes;

            query = query.AsNoTracking()
                .OrderBy(c => c.Id)
                .Where(cliente => cliente.Id == clienteId);

            return query.FirstOrDefault();
        }

        // Editoras
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

        // Livros

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


        public Livros[] GetAllLivrosByEditoraName() {
            throw new System.NotImplementedException();
        }

        //Alugueis
        public Alugueis[] GetAllAlugueis() {
            IQueryable<Alugueis> query = _context.Alugueis;



            query = query.Include(al => al.Cliente);
            query = query.Include(al => al.Livro);

            query = query.AsNoTracking().OrderBy(al => al.Id);

            return query.ToArray();
        }
        public Alugueis GetAluguelById(int aluguelId) {
            IQueryable<Alugueis> query = _context.Alugueis;



            query = query.Include(al => al.Cliente);
            query = query.Include(al => al.Livro);


            query = query.AsNoTracking()
                .OrderBy(al => al.Id)
                .Where(aluguel => aluguel.Id == aluguelId);

            return query.FirstOrDefault();
        }

        public Alugueis[] GetAllAlugueisByClientesName() {
            throw new System.NotImplementedException();
        }

        public Alugueis[] GetAllAlugueisByLivrosName() {
            throw new System.NotImplementedException();
        }


    }
}
