using Microsoft.EntityFrameworkCore.Migrations;

namespace _NetWebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    mail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    preco = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    data = table.Column<string>(type: "TEXT", nullable: true),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    desconto = table.Column<double>(type: "REAL", nullable: false),
                    valorFinal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    produtoId = table.Column<int>(type: "INTEGER", nullable: false),
                    valorUni = table.Column<double>(type: "REAL", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    desconto = table.Column<double>(type: "REAL", nullable: false),
                    valorFinal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Itens_Pedidos_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Itens_Produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "mail", "nome" },
                values: new object[] { 1, "aaa@aa.com", "Lauro" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "mail", "nome" },
                values: new object[] { 2, "bbb@aa.com", "Roberto" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "mail", "nome" },
                values: new object[] { 3, "ccc@aa.com", "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "mail", "nome" },
                values: new object[] { 4, "ddd@aa.com", "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "mail", "nome" },
                values: new object[] { 5, "eee@aa.com", "Alexandre" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "id", "nome", "preco" },
                values: new object[] { 1, "Macarrão", 1.1000000000000001 });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "id", "nome", "preco" },
                values: new object[] { 2, "Feijão", 2.0 });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "id", "nome", "preco" },
                values: new object[] { 3, "Azeitona", 3.5 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "id", "clienteId", "data", "desconto", "valor", "valorFinal" },
                values: new object[] { 1, 1, "01", 1.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "id", "clienteId", "data", "desconto", "valor", "valorFinal" },
                values: new object[] { 2, 3, "04", 0.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "id", "clienteId", "data", "desconto", "valor", "valorFinal" },
                values: new object[] { 3, 4, "14", 5.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "id", "desconto", "pedidoId", "produtoId", "quantidade", "valor", "valorFinal", "valorUni" },
                values: new object[] { 1, 0.0, 1, 1, 2, 2.2000000000000002, 2.2000000000000002, 1.1000000000000001 });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "id", "desconto", "pedidoId", "produtoId", "quantidade", "valor", "valorFinal", "valorUni" },
                values: new object[] { 2, 0.5, 1, 2, 1, 2.0, 1.5, 2.0 });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "id", "desconto", "pedidoId", "produtoId", "quantidade", "valor", "valorFinal", "valorUni" },
                values: new object[] { 3, 1.0, 1, 3, 1, 3.5, 2.5, 3.5 });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "id", "desconto", "pedidoId", "produtoId", "quantidade", "valor", "valorFinal", "valorUni" },
                values: new object[] { 4, 0.0, 2, 1, 2, 2.2000000000000002, 2.2000000000000002, 1.1000000000000001 });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "id", "desconto", "pedidoId", "produtoId", "quantidade", "valor", "valorFinal", "valorUni" },
                values: new object[] { 5, 1.0, 2, 3, 4, 14.0, 13.0, 3.5 });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "id", "desconto", "pedidoId", "produtoId", "quantidade", "valor", "valorFinal", "valorUni" },
                values: new object[] { 6, 2.0, 3, 2, 5, 10.0, 8.0, 2.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_pedidoId",
                table: "Itens",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_produtoId",
                table: "Itens",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteId",
                table: "Pedidos",
                column: "clienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
