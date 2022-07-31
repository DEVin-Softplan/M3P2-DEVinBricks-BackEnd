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
                values: new object[] { new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7117), new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(6385), new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7885), new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7881), new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7889), new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7888), new DateTime(2022, 7, 31, 13, 16, 58, 44, DateTimeKind.Local).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 13, 16, 58, 35, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 13, 16, 58, 45, DateTimeKind.Local).AddTicks(8196));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(220), new DateTime(2022, 7, 31, 13, 16, 44, 227, DateTimeKind.Local).AddTicks(9218), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(215) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1176), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1179) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1185), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1184), new DateTime(2022, 7, 31, 13, 16, 44, 228, DateTimeKind.Local).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 13, 16, 44, 210, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 7, 31, 13, 16, 44, 229, DateTimeKind.Local).AddTicks(4695));
        }
    }
}
