using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperColmadoDennys.Migrations
{
    /// <inheritdoc />
    public partial class inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CodigoBarras", "Descripcion", "EstaActivo", "FechaVencimiento", "ImagenUrl", "Nombre", "Precio", "ProveedorId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "1234567890123", null, true, null, "/Imagen/LecheEntera.png", "Leche Entera", 200m, 0, 50 },
                    { 2, 1, "1234567890124", null, true, null, "/Imagen/YogurNatural.jpg", "Yogur Natural", 300m, 0, 100 },
                    { 3, 2, "9876543210987", null, true, null, "/Imagen/PanIntegral.jpg", "Pan Integral", 60m, 0, 30 },
                    { 4, 2, "9876543210988", null, true, null, "/Imagen/Croissants.jpg", "Croissant", 300m, 0, 40 },
                    { 5, 3, "5555555555555", null, true, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Imagen/Atun.jpg", "Atún en lata", 400m, 0, 80 },
                    { 6, 3, "5555555555556", null, true, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Imagen/Sardina.jpg", "Sardinas en tomate", 125m, 0, 60 },
                    { 7, 3, "5555555555557", null, true, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Imagen/Maiz.jpg", "Maíz enlatado", 70m, 0, 90 },
                    { 8, 4, "1111111111111", null, true, null, "/Imagen/AguaSaratoga.jpg", "Agua Saratoga 1L", 500m, 0, 200 },
                    { 9, 4, "1111111111112", null, true, null, "/Imagen/Cocacola.jpg", "Coca Cola 2L", 80m, 0, 150 },
                    { 10, 5, "2222222222222", null, true, null, "/Imagen/Brugar.jpg", "Brugal ExtraViejo 700ml", 700m, 0, 100 },
                    { 11, 5, "2222222222223", null, true, null, "/Imagen/TripleReserva.jpg", "Brugal Triple Reserva", 1060m, 0, 100 }
                });
        }
    }
}
