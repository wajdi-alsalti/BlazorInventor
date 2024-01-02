using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityDBClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapNumber = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wagen_Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wagen_IdId = table.Column<int>(type: "int", nullable: false),
                    Material_IDId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagen_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wagen_Materials_Materials_Material_IDId",
                        column: x => x.Material_IDId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wagen_Materials_Wagens_Wagen_IdId",
                        column: x => x.Wagen_IdId,
                        principalTable: "Wagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bands_Wagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Band_IdId = table.Column<int>(type: "int", nullable: false),
                    Wagen_Materials_IdId = table.Column<int>(type: "int", nullable: false),
                    WagenPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands_Wagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bands_Wagens_Bands_Band_IdId",
                        column: x => x.Band_IdId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bands_Wagens_Wagen_Materials_Wagen_Materials_IdId",
                        column: x => x.Wagen_Materials_IdId,
                        principalTable: "Wagen_Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bands_Wagens_Band_IdId",
                table: "Bands_Wagens",
                column: "Band_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_Wagens_Wagen_Materials_IdId",
                table: "Bands_Wagens",
                column: "Wagen_Materials_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagen_Materials_Material_IDId",
                table: "Wagen_Materials",
                column: "Material_IDId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagen_Materials_Wagen_IdId",
                table: "Wagen_Materials",
                column: "Wagen_IdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bands_Wagens");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Wagen_Materials");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Wagens");
        }
    }
}
