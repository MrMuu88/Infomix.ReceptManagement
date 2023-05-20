using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleTables",
                columns: table => new
                {
                    SampleTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTables", x => x.SampleTableId);
                });

            migrationBuilder.CreateTable(
                name: "SampleTableElements",
                columns: table => new
                {
                    SampleTableElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTableElements", x => x.SampleTableElementId);
                    table.ForeignKey(
                        name: "FK_SampleTableElements_SampleTables_SampleTableId",
                        column: x => x.SampleTableId,
                        principalTable: "SampleTables",
                        principalColumn: "SampleTableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleTableElements_SampleTableId",
                table: "SampleTableElements",
                column: "SampleTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleTableElements");

            migrationBuilder.DropTable(
                name: "SampleTables");
        }
    }
}
