using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class SeedValorFretePorEstadoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 22, 20, 22, 12, 733, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.InsertData(
                table: "ValorFreteEstados",
                columns: new[] { "Id", "DataDeAlteracao", "DataDeInclusao", "EstadoId", "UsuarioAlteracaoId", "UsuarioInclusaoId", "Valor" },
                values: new object[] { 1, null, new DateTime(2022, 7, 22, 20, 22, 12, 735, DateTimeKind.Local).AddTicks(8833), 42, null, 1, 100m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 22, 19, 59, 4, 458, DateTimeKind.Local).AddTicks(6194));
        }
    }
}
