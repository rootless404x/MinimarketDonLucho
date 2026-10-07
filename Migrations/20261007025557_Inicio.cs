using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimarketDonLucho.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Abarrotes" },
                    { 2, "Bebidas" },
                    { 3, "Lácteos" },
                    { 4, "Limpieza" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "FechaVencimiento", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, null, "Arroz extra 5 kg", 24.90m, 18 },
                    { 2, 1, null, "Aceite vegetal 1 L", 11.50m, 3 },
                    { 3, 1, null, "Azúcar rubia 1 kg", 4.20m, 25 },
                    { 4, 2, new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaseosa 1.5 L", 7.50m, 0 },
                    { 5, 2, new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agua mineral 625 ml", 1.80m, 40 },
                    { 6, 3, new DateTime(2027, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leche evaporada 400 g", 4.10m, 30 },
                    { 7, 3, new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yogurt de fresa 1 L", 7.90m, 5 },
                    { 8, 4, null, "Detergente 750 g", 9.80m, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
