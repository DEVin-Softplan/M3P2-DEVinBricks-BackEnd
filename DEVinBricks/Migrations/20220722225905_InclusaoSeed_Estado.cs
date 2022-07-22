using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class InclusaoSeed_Estado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioAlteracao",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdUsuarioInclusao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 22, 19, 59, 4, 458, DateTimeKind.Local).AddTicks(6194));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DropColumn(
                name: "IdUsuarioAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdUsuarioInclusao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Estados");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "Produtos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 21, 21, 33, 5, 633, DateTimeKind.Local).AddTicks(2112));
        }
    }
}
