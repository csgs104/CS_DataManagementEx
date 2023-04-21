using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ex3.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id_Artist = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id_Artist);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id_Character = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id_Character);
                });

            migrationBuilder.CreateTable(
                name: "Museum",
                columns: table => new
                {
                    Id_Museum = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museum", x => x.Id_Museum);
                });

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    Id_Character = table.Column<int>(type: "int", nullable: false),
                    Id_Artwork = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id_Museum = table.Column<int>(type: "int", nullable: false),
                    Id_Artist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artwork", x => x.Id_Character);
                    table.ForeignKey(
                        name: "FK_Id_Artist",
                        column: x => x.Id_Artist,
                        principalTable: "Artist",
                        principalColumn: "Id_Artist");
                    table.ForeignKey(
                        name: "FK_Id_Character",
                        column: x => x.Id_Character,
                        principalTable: "Character",
                        principalColumn: "Id_Character");
                    table.ForeignKey(
                        name: "FK_Id_Museum",
                        column: x => x.Id_Museum,
                        principalTable: "Museum",
                        principalColumn: "Id_Museum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_Id_Artist",
                table: "Artwork",
                column: "Id_Artist");

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_Id_Museum",
                table: "Artwork",
                column: "Id_Museum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Museum");
        }
    }
}
