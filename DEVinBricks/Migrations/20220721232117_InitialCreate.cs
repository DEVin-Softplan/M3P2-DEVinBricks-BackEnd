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
                        .Annotation("SqlServer:Identity", "1, 1")
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
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
                    DataDeInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInclusaoId = table.Column<int>(type: "int", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendasProdutos", x => x.Id);
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_UsuarioAlteracaoId",
                table: "Compradores",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_UsuarioInclusaoId",
                table: "Compradores",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fretes_UsuarioAlteracaoId",
                table: "Fretes",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fretes_UsuarioInclusaoId",
                table: "Fretes",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioAlteracaoId",
                table: "Produtos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioInclusaoId",
                table: "Produtos",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioAlteracaoId",
                table: "Usuarios",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioInclusaoId",
                table: "Usuarios",
                column: "UsuarioInclusaoId",
                unique: true);

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
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioAlteracaoId",
                table: "Vendas",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioInclusaoId",
                table: "Vendas",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_UsuarioAlteracaoId",
                table: "VendasProdutos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_UsuarioInclusaoId",
                table: "VendasProdutos",
                column: "UsuarioInclusaoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compradores");

            migrationBuilder.DropTable(
                name: "Fretes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ValorFreteEstados");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "VendasProdutos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
