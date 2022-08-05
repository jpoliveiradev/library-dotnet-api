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
/*
        // Editoras
        public Editoras[] GetAllEditoras() {
            
        }

        public Editoras GetEditora() {
            
        }

        // Livros
        public Livros[] GetAllLivros() {
            
        }

        public Livros[] GetAllLivrosByEditoraId() {
            
        }

        public Livros GetLivro() {
            
        }*/
    }
}
