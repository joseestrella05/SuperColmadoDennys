using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperColmadoDennys.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provedores",
                columns: table => new
                {
                    ProvedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provedores", x => x.ProvedorId);
                });

            migrationBuilder.InsertData(
                table: "Provedores",
                columns: new[] { "ProvedorId", "Correo", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "servicioalcliente@induveca.com.do.", "calle jino negrin", "Induveca", "8098444618" },
                    { 2, "servicios.consumidor@do.nestle.com.", "Carretera nagua", "Nestle", "8095882870" },
                    { 3, "atencion.consumidor@baldom.net", "calle jino negrin", "Baldom", "8092002108" },
                    { 4, "servicioalcliente@CND.com.do.", "calle hermana mirabal", "Cerveceria nacional", "8094873200" },
                    { 5, "servicioalcliente@Yoma.com.do.", "Avenida libertad", "Yoma", "8095884606" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provedores");
        }
    }
}
