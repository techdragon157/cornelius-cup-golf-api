using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorneliusCup.Golf.API.Migrations
{
    public partial class ChangeTeeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tees",
                newName: "TeeType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tee<HoleScore>",
                newName: "TeeType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeeType",
                table: "Tees",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TeeType",
                table: "Tee<HoleScore>",
                newName: "Type");
        }
    }
}
