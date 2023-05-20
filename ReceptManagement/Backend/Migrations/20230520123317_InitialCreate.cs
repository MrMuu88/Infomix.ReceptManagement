using System;
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
                name: "BNOk",
                columns: table => new
                {
                    BNOId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BNOKod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BetegsegNeve = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BNOk", x => x.BNOId);
                });

            migrationBuilder.CreateTable(
                name: "Paciensek",
                columns: table => new
                {
                    PaciensId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Szuletesnap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TAJ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciensek", x => x.PaciensId);
                });

            migrationBuilder.CreateTable(
                name: "Receptek",
                columns: table => new
                {
                    ReceptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceptKiallitasDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceptSzovege = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AltalanosJogcimmel = table.Column<bool>(type: "bit", nullable: false),
                    Kozgyogyellatottnak = table.Column<bool>(type: "bit", nullable: false),
                    EURendelkezessel = table.Column<bool>(type: "bit", nullable: false),
                    EUTeritesKotelesAronRendelve = table.Column<bool>(type: "bit", nullable: false),
                    TeljesAronRendelve = table.Column<bool>(type: "bit", nullable: false),
                    Helyettesitheto = table.Column<bool>(type: "bit", nullable: false),
                    PaciensId = table.Column<int>(type: "int", nullable: false),
                    BNOId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptek", x => x.ReceptId);
                    table.ForeignKey(
                        name: "FK_Receptek_BNOk_BNOId",
                        column: x => x.BNOId,
                        principalTable: "BNOk",
                        principalColumn: "BNOId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptek_Paciensek_PaciensId",
                        column: x => x.PaciensId,
                        principalTable: "Paciensek",
                        principalColumn: "PaciensId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptek_BNOId",
                table: "Receptek",
                column: "BNOId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptek_PaciensId",
                table: "Receptek",
                column: "PaciensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receptek");

            migrationBuilder.DropTable(
                name: "BNOk");

            migrationBuilder.DropTable(
                name: "Paciensek");
        }
    }
}
