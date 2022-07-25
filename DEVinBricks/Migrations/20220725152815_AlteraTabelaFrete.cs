using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class AlteraTabelaFrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VendasProdutos_UsuarioInclusaoId",
                table: "VendasProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioInclusaoId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_ValorFreteEstados_UsuarioInclusaoId",
                table: "ValorFreteEstados");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioInclusaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Fretes_UsuarioInclusaoId",
                table: "Fretes");

            migrationBuilder.DropIndex(
                name: "IX_Compradores_UsuarioInclusaoId",
                table: "Compradores");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Fretes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Fretes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Fretes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Fretes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeEntrega",
                table: "Fretes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Fretes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Logadouro",
                table: "Fretes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFrete",
                table: "Fretes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Fretes",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Complemento", "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao", "EstadoId", "Logadouro", "UsuarioAlteracaoId", "UsuarioInclusaoId", "ValorFrete" },
                values: new object[,]
                {
                    { 1, "Vasco", "0123456-789", "Porto Velho", "Casa 98", new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8391), new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8001), new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8389), 11, "Rua Vasco da Gama, 123", 1, 1, 27m },
                    { 2, "T-REX", "345631-127", "Parque Jurassico", "Casa 47", new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8861), new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8858), new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8860), 12, "Rua Dino, 456", 2, 2, 53m },
                    { 3, "Acai", "999999-888", "Manaus", "Casa 12", new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8865), new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8863), new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(8864), 13, "Rua do Acai, 789", 3, 3, 32m }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 25, 12, 28, 14, 473, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 25, 12, 28, 14, 477, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_UsuarioInclusaoId",
                table: "VendasProdutos",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioInclusaoId",
                table: "Vendas",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorFreteEstados_UsuarioInclusaoId",
                table: "ValorFreteEstados",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioInclusaoId",
                table: "Produtos",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fretes_UsuarioInclusaoId",
                table: "Fretes",
                column: "UsuarioInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_UsuarioInclusaoId",
                table: "Compradores",
                column: "UsuarioInclusaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VendasProdutos_UsuarioInclusaoId",
                table: "VendasProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioInclusaoId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_ValorFreteEstados_UsuarioInclusaoId",
                table: "ValorFreteEstados");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioInclusaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Fretes_UsuarioInclusaoId",
                table: "Fretes");

            migrationBuilder.DropIndex(
                name: "IX_Compradores_UsuarioInclusaoId",
                table: "Compradores");

            migrationBuilder.DeleteData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "DataDeEntrega",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "Logadouro",
                table: "Fretes");

            migrationBuilder.DropColumn(
                name: "ValorFrete",
                table: "Fretes");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 24, 10, 51, 9, 914, DateTimeKind.Local).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 24, 10, 51, 9, 917, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.CreateIndex(
                name: "IX_VendasProdutos_UsuarioInclusaoId",
                table: "VendasProdutos",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioInclusaoId",
                table: "Vendas",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValorFreteEstados_UsuarioInclusaoId",
                table: "ValorFreteEstados",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioInclusaoId",
                table: "Produtos",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fretes_UsuarioInclusaoId",
                table: "Fretes",
                column: "UsuarioInclusaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_UsuarioInclusaoId",
                table: "Compradores",
                column: "UsuarioInclusaoId",
                unique: true);
        }
    }
}
