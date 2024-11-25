using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TMTmantencion.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    disponibilidad = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    kilometros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chofer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    disponibilidad = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    kilometros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tramo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    distancia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "viaje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idtramo = table.Column<int>(name: "id_tramo", type: "int", nullable: false),
                    idbus = table.Column<int>(name: "id_bus", type: "int", nullable: false),
                    idchofer = table.Column<int>(name: "id_chofer", type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "viaje_ibfk_1",
                        column: x => x.idbus,
                        principalTable: "bus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "viaje_ibfk_2",
                        column: x => x.idchofer,
                        principalTable: "chofer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "viaje_ibfk_3",
                        column: x => x.idtramo,
                        principalTable: "tramo",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "patente",
                table: "bus",
                column: "patente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_bus",
                table: "viaje",
                column: "id_bus");

            migrationBuilder.CreateIndex(
                name: "id_chofer",
                table: "viaje",
                column: "id_chofer");

            migrationBuilder.CreateIndex(
                name: "id_tramo",
                table: "viaje",
                column: "id_tramo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "viaje");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "chofer");

            migrationBuilder.DropTable(
                name: "tramo");
        }
    }
}
