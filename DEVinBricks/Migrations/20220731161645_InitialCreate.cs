using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Compradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compradores_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compradores_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fretes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logadouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fretes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fretes_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fretes_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlDaImagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ValorFreteEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorFreteEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorFreteEstados_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValorFreteEstados_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValorFreteEstados_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompradorId = table.Column<int>(type: "int", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    FreteIdId = table.Column<int>(type: "int", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Fretes_FreteIdId",
                        column: x => x.FreteIdId,
                        principalTable: "Fretes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendasProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVendaId = table.Column<int>(type: "int", nullable: false),
                    IdProdutoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendasProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendasProdutos_Produtos_IdProdutoId",
                        column: x => x.IdProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendasProdutos_Usuarios_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendasProdutos_Usuarios_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendasProdutos_Vendas_IdVendaId",
                        column: x => x.IdVendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nome", "UF" },
                values: new object[,]
                {
                    { 11, "Rondônia", "RO" },
                    { 12, "Acre", "AC" },
                    { 13, "Amazonas", "AM" },
                    { 14, "Roraima", "RR" },
                    { 15, "Pará", "PA" },
                    { 16, "Amapá", "AP" },
                    { 17, "Tocantins", "TO" },
                    { 21, "Maranhão", "MA" },
                    { 22, "Piauí", "PI" },
                    { 23, "Ceará", "CE" },
                    { 24, "Rio Grande do Norte", "RN" },
                    { 25, "Paraíba", "PB" },
                    { 26, "Pernanmbuco", "PE" },
                    { 27, "Alagoas", "AL" },
                    { 28, "Sergipe", "SE" },
                    { 29, "Bahia", "BA" },
                    { 31, "Minas Gerais", "MG" },
                    { 32, "Espírito Santo", "ES" },
                    { 33, "Rio de Janeiro", "RJ" },
                    { 35, "São Paulo", "SP" },
                    { 41, "Paraná", "PR" },
                    { 42, "Santa Catarina", "SC" },
                    { 43, "Rio Grande do Sul", "RS" },
                    { 50, "Mato Grosso do Sul", "MS" },
                    { 51, "Mato Grosso", "MT" },
                    { 52, "Goiás", "GO" },
                    { 53, "Distrito Federal", "DF" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Admin", "Ativo", "DataDeAlteracao", "DataDeInclusao", "Email", "Login", "Nome", "Senha", "UsuarioAlteracaoId", "UsuarioInclusaoId" },
                values: new object[] { 1, true, true, null, new DateTime(2022, 7, 31, 13, 16, 44, 210, DateTimeKind.Local).AddTicks(7078), "admin@gmail.com", "admin", "Admin", "admin123", null, 1 });

            migrationBuilder.InsertData(
                table: "Compradores",
                columns: new[] { "Id", "Ativo", "CPF", "DataDeAlteracao", "DataDeInclusao", "DataDeNascimento", "Email", "Nome", "Telefone", "UsuarioAlteracaoId", "UsuarioInclusaoId" },
                values: new object[,]
                {
                    { 1, true, "34602022030", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "comprador1@comprador.com.br", "Comprador 1", "1234567891", null, 1 },
                    { 2, true, "13574152060", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "comprador2@comprador.com.br", "Comprador 2", "1234567892", null, 1 },
                    { 3, true, "57394817083", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "comprador3@comprador.com.br", "Comprador 3", "1234567893", null, 1 },
                    { 4, true, "39921234056", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "comprador4@comprador.com.br", "Comprador 4", "1234567894", null, 1 },
                    { 5, true, "80202128091", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "comprador5@comprador.com.br", "Comprador 5", "1234567895", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Fretes",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Complemento", "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao", "EstadoId", "Logadouro", "UsuarioAlteracaoId", "UsuarioInclusaoId", "ValorFrete" },
                values: new object[,]
                {
                    { 1, "Vasco", "0123456-789", "Porto Velho", "Casa 98", new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(220), new DateTime(2022, 7, 31, 13, 16, 44, 227, DateTimeKind.Local).AddTicks(9218), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(215), 11, "Rua Vasco da Gama, 123", 1, 1, 27m },
                    { 2, "T-REX", "345631-127", "Parque Jurassico", "Casa 47", new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1176), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1179), 12, "Rua Dino, 456", 1, 1, 53m },
                    { 3, "Acai", "999999-888", "Manaus", "Casa 12", new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1185), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1184), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1184), 13, "Rua do Acai, 789", 1, 1, 32m }
                });

            migrationBuilder.InsertData(
                table: "ValorFreteEstados",
                columns: new[] { "Id", "DataDeAlteracao", "DataDeInclusao", "EstadoId", "UsuarioAlteracaoId", "UsuarioInclusaoId", "Valor" },
                values: new object[] { 1, null, new DateTime(2022, 7, 31, 13, 16, 44, 229, DateTimeKind.Local).AddTicks(4695), 42, null, 1, 100m });

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_UsuarioAlteracaoId",
                table: "Compradores",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_UsuarioInclusaoId",
                table: "Compradores",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fretes_UsuarioAlteracaoId",
                table: "Fretes",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fretes_UsuarioInclusaoId",
                table: "Fretes",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioAlteracaoId",
                table: "Produtos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioInclusaoId",
                table: "Produtos",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioAlteracaoId",
                table: "Usuarios",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioInclusaoId",
                table: "Usuarios",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorFreteEstados_EstadoId",
                table: "ValorFreteEstados",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorFreteEstados_UsuarioAlteracaoId",
                table: "ValorFreteEstados",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorFreteEstados_UsuarioInclusaoId",
                table: "ValorFreteEstados",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FreteIdId",
                table: "Vendas",
                column: "FreteIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioAlteracaoId",
                table: "Vendas",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioInclusaoId",
                table: "Vendas",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_IdProdutoId",
                table: "VendasProdutos",
                column: "IdProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_IdVendaId",
                table: "VendasProdutos",
                column: "IdVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_UsuarioAlteracaoId",
                table: "VendasProdutos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_UsuarioInclusaoId",
                table: "VendasProdutos",
                column: "UsuarioInclusaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compradores");

            migrationBuilder.DropTable(
                name: "ValorFreteEstados");

            migrationBuilder.DropTable(
                name: "VendasProdutos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Fretes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
