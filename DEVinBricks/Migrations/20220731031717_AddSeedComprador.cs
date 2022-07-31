using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class AddSeedComprador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(5194), new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(4403), new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(5190) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(6524), new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(6516), new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(6523) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(6529), new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(6527), new DateTime(2022, 7, 31, 0, 17, 16, 315, DateTimeKind.Local).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 0, 17, 16, 311, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 0, 17, 16, 316, DateTimeKind.Local).AddTicks(7688));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(6848), new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(6148), new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(6844) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(7525), new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(7522), new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(7529), new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(7528), new DateTime(2022, 7, 31, 0, 16, 45, 339, DateTimeKind.Local).AddTicks(7528) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 0, 16, 45, 335, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 0, 16, 45, 340, DateTimeKind.Local).AddTicks(8188));
        }
    }
}
