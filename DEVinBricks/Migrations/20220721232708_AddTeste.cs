using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class AddTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DESGRACA",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESGRACA",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IdUsuarioAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdUsuarioInclusao",
                table: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "Produtos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
