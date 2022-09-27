using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class initMysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeAdmin = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeEditora = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeLivro = table.Column<string>(nullable: true),
                    EditoraId = table.Column<int>(nullable: false),
                    Autor = table.Column<string>(nullable: true),
                    Lancamento = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    QuantAlugado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LivroId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    DataAluguel = table.Column<DateTime>(nullable: false),
                    DataPrevisao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alugueis_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alugueis_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Endereco", "NomeAdmin", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "jp123@gmail.com", "Rua A Cascavel", "JP Souza", "jp1234", "jpsouza" },
                    { 2, "art123@gmail.com", "Rua A Cascavel", "Arthur", "jp1234", "jpsouza" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cidade", "Email", "Endereco", "NomeUsuario" },
                values: new object[,]
                {
                    { 1, "Cascavel", "Artur@gmail.com", "Rua A", "Artur" },
                    { 2, "Caucaia", "Ana@gmail.com", "Rua T", "Ana" },
                    { 3, "São Paulo", "Vilma@gmail.com", "Rua K", "Vilma" },
                    { 4, "Fortaleza", "Vitor@gmail.com", "Rua E", "Vitor" }
                });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "Cidade", "NomeEditora" },
                values: new object[,]
                {
                    { 1, "Cascavel", "Artur" },
                    { 2, "Caucaia", "Ana" },
                    { 3, "São Paulo", "Vilma" },
                    { 4, "Fortaleza", "Vitor" },
                    { 5, "Fortaleza", "Caio" },
                    { 6, "Fortaleza", "Henrique" },
                    { 7, "Fortaleza", "Laurence" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "NomeLivro", "QuantAlugado", "Quantidade" },
                values: new object[,]
                {
                    { 3, "Elephant", 1, new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Php", 0, 7 },
                    { 1, "Navathe", 2, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banco de Dados", 0, 10 },
                    { 2, "Deitel", 3, new DateTime(2015, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java Prático", 0, 10 },
                    { 4, "Cormen", 4, new DateTime(2016, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vue JS", 0, 55 },
                    { 5, "Git", 5, new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "GitHub", 0, 5 },
                    { 6, "Café", 6, new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", 0, 22 },
                    { 7, "Algoritmo", 7, new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Código Limpo", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "DataAluguel", "DataDevolucao", "DataPrevisao", "LivroId" },
                values: new object[] { 3, 1, new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "DataAluguel", "DataDevolucao", "DataPrevisao", "LivroId" },
                values: new object[] { 1, 2, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "DataAluguel", "DataDevolucao", "DataPrevisao", "LivroId" },
                values: new object[] { 2, 3, new DateTime(2015, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_ClienteId",
                table: "Alugueis",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_LivroId",
                table: "Alugueis",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraId",
                table: "Livros",
                column: "EditoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
