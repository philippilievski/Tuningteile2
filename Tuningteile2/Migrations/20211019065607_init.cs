using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashPw = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Modells",
                columns: table => new
                {
                    ModellID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearManufactured = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modells", x => x.ModellID);
                });

            migrationBuilder.CreateTable(
                name: "Tuningparts",
                columns: table => new
                {
                    TuningpartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Avaliability = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuningparts", x => x.TuningpartID);
                    table.ForeignKey(
                        name: "FK_Tuningparts_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModellTuningparts",
                columns: table => new
                {
                    ModellTuningpartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModellID = table.Column<int>(type: "int", nullable: true),
                    TuningpartID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModellTuningparts", x => x.ModellTuningpartID);
                    table.ForeignKey(
                        name: "FK_ModellTuningparts_Modells_ModellID",
                        column: x => x.ModellID,
                        principalTable: "Modells",
                        principalColumn: "ModellID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModellTuningparts_Tuningparts_TuningpartID",
                        column: x => x.TuningpartID,
                        principalTable: "Tuningparts",
                        principalColumn: "TuningpartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModellTuningparts_ModellID",
                table: "ModellTuningparts",
                column: "ModellID");

            migrationBuilder.CreateIndex(
                name: "IX_ModellTuningparts_TuningpartID",
                table: "ModellTuningparts",
                column: "TuningpartID");

            migrationBuilder.CreateIndex(
                name: "IX_Tuningparts_CategoryID",
                table: "Tuningparts",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ModellTuningparts");

            migrationBuilder.DropTable(
                name: "Modells");

            migrationBuilder.DropTable(
                name: "Tuningparts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
