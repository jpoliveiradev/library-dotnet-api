using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Library.API.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Editoras> Editoras { get; set; }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Alugueis> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<Clientes>()
            .HasData(new List<Clientes>(){
                new Clientes(1, "Artur", "Cascavel", "Rua A", "Artur@gmail.com"),
                new Clientes(2, "Ana", "Caucaia", "Rua T", "Ana@gmail.com"),
                new Clientes(3, "Vilma", "São Paulo", "Rua K", "Vilma@gmail.com"),
                new Clientes(4, "Vitor", "Fortaleza", "Rua E", "Vitor@gmail.com")

            });

            builder.Entity<Editoras>()
            .HasData(new List<Editoras>(){
                new Editoras(1, "Artur", "Cascavel"),
                new Editoras(2, "Ana", "Caucaia"),
                new Editoras(3, "Vilma", "São Paulo"),
                new Editoras(4, "Vitor", "Fortaleza")

            });

            builder.Entity<Livros>()
            .HasData(new List<Livros>(){
                new Livros(1, "Banco de Dados", 2, "Navathe", 2002),
                new Livros(2, "Java Prático", 3, "Deitel", 2005),
                new Livros(3, "Php", 3, "Deitel", 2010),
                new Livros(4, "Vue JS", 3, "Cormen", 2021)

            });

            builder.Entity<Alugueis>()
            .HasData(new List<Alugueis>(){
                new Alugueis(1, 2, 2, DateTime.Parse("10/02/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("24/02/2010")),
                new Alugueis(2, 1, 2, DateTime.Parse("1/11/2021"), DateTime.Parse("30/12/2010"), DateTime.Parse("3/02/2010")),
                new Alugueis(3, 4, 2, DateTime.Parse("3/5/2015"), DateTime.Parse("20/8/2010"), DateTime.Parse("31/12/2010")),
                new Alugueis(4, 3, 2, DateTime.Parse("22/3/2022"), DateTime.Parse("20/02/2010"), DateTime.Parse("20/02/2010"))
                
            });

        }

    }
}
