using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Editoras> Editoras { get; set; }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Alugueis> Alugueis { get; set; }
        public DbSet<Login> Login { get; set; }


        protected override void OnModelCreating(ModelBuilder buider) {
            //buider.Entity<Clientes>();
        }

    }
}
