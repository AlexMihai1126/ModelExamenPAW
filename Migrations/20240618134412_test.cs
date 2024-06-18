using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelExamen.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piloti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    Nationalitate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piloti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zboruri",
                columns: table => new
                {
                    ZborId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AeroportPlecare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AeroportDestinatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PilotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zboruri", x => x.ZborId);
                    table.ForeignKey(
                        name: "FK_Zboruri_Piloti_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Piloti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zboruri_PilotId",
                table: "Zboruri",
                column: "PilotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zboruri");

            migrationBuilder.DropTable(
                name: "Piloti");
        }
    }
}
