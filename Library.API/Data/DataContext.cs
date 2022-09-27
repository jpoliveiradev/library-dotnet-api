using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Library.API.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Editoras> Editoras { get; set; }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Alugueis> Alugueis { get; set; }
        public DbSet<Admins> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<Clientes>()
            .HasData(new List<Clientes>(){
                new Clientes(1, "Artur",  "Rua A","Cascavel", "Artur@gmail.com"),
                new Clientes(2, "Ana",  "Rua T","Caucaia", "Ana@gmail.com"),
                new Clientes(3, "Vilma",  "Rua K", "São Paulo", "Vilma@gmail.com"),
                new Clientes(4, "Vitor", "Rua E", "Fortaleza", "Vitor@gmail.com")

            });

            builder.Entity<Editoras>()
            .HasData(new List<Editoras>(){
                new Editoras(1, "Artur", "Cascavel"),
                new Editoras(2, "Ana", "Caucaia"),
                new Editoras(3, "Vilma", "São Paulo"),
                new Editoras(4, "Vitor", "Fortaleza"),
                new Editoras(5, "Caio", "Fortaleza"),
                new Editoras(6, "Henrique", "Fortaleza"),
                new Editoras(7, "Laurence", "Fortaleza"),

            });

            builder.Entity<Livros>()
            .HasData(new List<Livros>(){
                new Livros(1, "Banco de Dados", 2, "Navathe", DateTime.Parse("14/10/2010"), 10),
                new Livros(2, "Java Prático", 3, "Deitel", DateTime.Parse("14/11/2015"), 10),
                new Livros(3, "Php", 1, "Elephant", DateTime.Parse("01/08/2018"), 7),
                new Livros(4, "Vue JS", 4, "Cormen", DateTime.Parse("22/12/2016"), 55),
                new Livros(5, "GitHub", 5, "Git", DateTime.Parse("08/03/2020"), 5),
                new Livros(6, "JavaScript", 6, "Café", DateTime.Parse("30/10/2021"), 22),
                new Livros(7, "Código Limpo", 7, "Algoritmo", DateTime.Parse("26/08/2022"), 2),

            });

            builder.Entity<Alugueis>()
            .HasData(new List<Alugueis>(){
            new Alugueis(1, 1, 2, DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010")),
            new Alugueis(2, 2, 3, DateTime.Parse("14/11/2015"), DateTime.Parse("14/11/2015"), DateTime.Parse("14/11/2015")),
            new Alugueis(3, 3, 1, DateTime.Parse("01/08/2018"), DateTime.Parse("01/08/2018"), DateTime.Parse("01/08/2018")),


            });
           

        }

    }
}
