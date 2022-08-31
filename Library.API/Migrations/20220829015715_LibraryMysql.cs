using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class LibraryMysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Quantidade = table.Column<int>(nullable: false)
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
                    DataDevolucao = table.Column<DateTime>(nullable: false)
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
                    { 4, "Fortaleza", "Vitor" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "NomeLivro", "Quantidade" },
                values: new object[,]
                {
                    { 1, "Navathe", 2, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banco de Dados", 5 },
                    { 2, "Deitel", 3, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java Prático", 5 },
                    { 3, "Deitel", 3, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Php", 5 },
                    { 4, "Cormen", 3, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vue JS", 5 }
                });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "DataAluguel", "DataDevolucao", "DataPrevisao", "LivroId" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, 2, new DateTime(2010, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 2, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 2, new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

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
