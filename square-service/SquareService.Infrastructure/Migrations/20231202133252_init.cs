using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquareService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointLists",
                columns: table => new
                {
                    PointListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointLists", x => x.PointListId);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    PointListId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => new { x.PointListId, x.Id });
                    table.ForeignKey(
                        name: "FK_Point_PointLists_PointListId",
                        column: x => x.PointListId,
                        principalTable: "PointLists",
                        principalColumn: "PointListId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "PointLists");
        }
    }
}
