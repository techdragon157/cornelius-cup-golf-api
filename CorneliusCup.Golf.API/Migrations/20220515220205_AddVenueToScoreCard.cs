using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorneliusCup.Golf.API.Migrations
{
    public partial class AddVenueToScoreCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "ScoreCards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_VenueId",
                table: "ScoreCards",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Venues_VenueId",
                table: "ScoreCards",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Venues_VenueId",
                table: "ScoreCards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCards_VenueId",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "ScoreCards");
        }
    }
}
