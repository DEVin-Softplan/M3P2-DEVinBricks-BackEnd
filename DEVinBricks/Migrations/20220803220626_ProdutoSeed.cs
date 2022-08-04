using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinBricks.Migrations
{
    public partial class ProdutoSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fretes_FreteIdId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "FreteIdId",
                table: "Vendas",
                newName: "FreteId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_FreteIdId",
                table: "Vendas",
                newName: "IX_Vendas_FreteId");

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5288), new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(4922), new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5286) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5703), new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5705) });

            migrationBuilder.UpdateData(
                table: "Fretes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataDeAlteracao", "DataDeEntrega", "DataDeInclusao" },
                values: new object[] { new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5709), new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5708), new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5708) });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "DataDeAlteracao", "DataDeInclusao", "Descricao", "Nome", "UrlDaImagem", "UsuarioAlteracaoId", "UsuarioInclusaoId", "Valor" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cimento top", "Cimento", "https://balaroti.vtexassets.com/arquivos/ids/2578293/7278.jpg?v=637508061483670000", null, 1, 200m },
                    { 2, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Areia top", "Areia", "https://cdn.leroymerlin.com.br/products/areia_fina_lavada_saco_20kg_grupo_tomino_89851650_636e_300x300.jpg", null, 1, 100m },
                    { 3, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bitoneira top", "Bitoneira", "https://a-static.mlcdn.com.br/1500x1500/betoneira-400-litros-com-motor-1-traco-super-csm/palaciodasferramentas/53812/7c7b9bfadd0b3063f3adf248843ed9fa.jpg", null, 1, 100000m }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 8, 3, 19, 6, 25, 818, DateTimeKind.Local).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "ValorFreteEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeInclusao",
                value: new DateTime(2022, 8, 3, 19, 6, 25, 826, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CompradorId",
                table: "Vendas",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Compradores_CompradorId",
                table: "Vendas",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fretes_FreteId",
                table: "Vendas",
                column: "FreteId",
                principalTable: "Fretes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuarios_VendedorId",
                table: "Vendas",
                column: "VendedorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Compradores_CompradorId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Fretes_FreteId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuarios_VendedorId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_CompradorId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas");

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "FreteId",
                table: "Vendas",
                newName: "FreteIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_FreteId",
                table: "Vendas",
                newName: "IX_Vendas_FreteIdId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Fretes_FreteIdId",
                table: "Vendas",
                column: "FreteIdId",
                principalTable: "Fretes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
