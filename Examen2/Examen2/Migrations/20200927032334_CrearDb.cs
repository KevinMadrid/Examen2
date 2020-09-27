using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen2.Migrations
{
    public partial class CrearDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Ciudads",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_ciudad = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudads", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ciudadano",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    primer_nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    segundo_nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    primer_apellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    segundo_apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    foto_ciudadano = table.Column<string>(nullable: true),
                    numero_telefono = table.Column<string>(nullable: true),
                    ciudadid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudadano", x => x.id);
                    table.ForeignKey(
                        name: "FK_ciudadano_Ciudads_ciudadid",
                        column: x => x.ciudadid,
                        principalTable: "Ciudads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudadano_ciudadid",
                schema: "dbo",
                table: "ciudadano",
                column: "ciudadid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ciudadano",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ciudads");
        }
    }
}
