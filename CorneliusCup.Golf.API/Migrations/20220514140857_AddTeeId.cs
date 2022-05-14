using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorneliusCup.Golf.API.Migrations
{
    public partial class AddTeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tees",
                newName: "TeeId");

            migrationBuilder.AddColumn<int>(
                name: "TeeId",
                table: "Tee<HoleScore>",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeeId",
                table: "Tee<HoleScore>");

            migrationBuilder.RenameColumn(
                name: "TeeId",
                table: "Tees",
                newName: "Id");
        }
    }
}
