using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile2.Migrations
{
    public partial class brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Modells",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modells_BrandID",
                table: "Modells",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Modells_Brands_BrandID",
                table: "Modells",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modells_Brands_BrandID",
                table: "Modells");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Modells_BrandID",
                table: "Modells");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Modells");
        }
    }
}
