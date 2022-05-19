using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CorneliusCup.Golf.API.Migrations
{
    public partial class TableUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GolfCourses_Venues_VenueId",
                table: "GolfCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_HoleScore_Tee<HoleScore>_Tee<HoleScore>ScoreCardId_Tee<Hole~",
                table: "HoleScore");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Competitions_CompetitionId",
                table: "ScoreCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_GolfCourses_GolfCourseId",
                table: "ScoreCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Players_PlayerId",
                table: "ScoreCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Venues_VenueId",
                table: "ScoreCards");

            migrationBuilder.DropTable(
                name: "Tee<HoleScore>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoleScore",
                table: "HoleScore");

            migrationBuilder.DropColumn(
                name: "Tee<HoleScore>Id",
                table: "HoleScore");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "ScoreCards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "ScoreCards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GolfCourseId",
                table: "ScoreCards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionId",
                table: "ScoreCards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeeId",
                table: "ScoreCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tee_CourseRating",
                table: "ScoreCards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tee_Par",
                table: "ScoreCards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tee_SSS",
                table: "ScoreCards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tee_SlopeRating",
                table: "ScoreCards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tee_TeeId",
                table: "ScoreCards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tee_TeeType",
                table: "ScoreCards",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "GolfCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoleScore",
                table: "HoleScore",
                columns: new[] { "Tee<HoleScore>ScoreCardId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_GolfCourses_Venues_VenueId",
                table: "GolfCourses",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoleScore_ScoreCards_Tee<HoleScore>ScoreCardId",
                table: "HoleScore",
                column: "Tee<HoleScore>ScoreCardId",
                principalTable: "ScoreCards",
                principalColumn: "ScoreCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Competitions_CompetitionId",
                table: "ScoreCards",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_GolfCourses_GolfCourseId",
                table: "ScoreCards",
                column: "GolfCourseId",
                principalTable: "GolfCourses",
                principalColumn: "GolfCourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Players_PlayerId",
                table: "ScoreCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Venues_VenueId",
                table: "ScoreCards",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GolfCourses_Venues_VenueId",
                table: "GolfCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_HoleScore_ScoreCards_Tee<HoleScore>ScoreCardId",
                table: "HoleScore");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Competitions_CompetitionId",
                table: "ScoreCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_GolfCourses_GolfCourseId",
                table: "ScoreCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Players_PlayerId",
                table: "ScoreCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Venues_VenueId",
                table: "ScoreCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoleScore",
                table: "HoleScore");

            migrationBuilder.DropColumn(
                name: "TeeId",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "Tee_CourseRating",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "Tee_Par",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "Tee_SSS",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "Tee_SlopeRating",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "Tee_TeeId",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "Tee_TeeType",
                table: "ScoreCards");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "ScoreCards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "ScoreCards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "GolfCourseId",
                table: "ScoreCards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionId",
                table: "ScoreCards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Tee<HoleScore>Id",
                table: "HoleScore",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "GolfCourses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoleScore",
                table: "HoleScore",
                columns: new[] { "Tee<HoleScore>ScoreCardId", "Tee<HoleScore>Id", "Id" });

            migrationBuilder.CreateTable(
                name: "Tee<HoleScore>",
                columns: table => new
                {
                    ScoreCardId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseRating = table.Column<int>(type: "integer", nullable: false),
                    Par = table.Column<int>(type: "integer", nullable: false),
                    SSS = table.Column<int>(type: "integer", nullable: false),
                    SlopeRating = table.Column<int>(type: "integer", nullable: false),
                    TeeId = table.Column<int>(type: "integer", nullable: false),
                    TeeType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tee<HoleScore>", x => new { x.ScoreCardId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tee<HoleScore>_ScoreCards_ScoreCardId",
                        column: x => x.ScoreCardId,
                        principalTable: "ScoreCards",
                        principalColumn: "ScoreCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GolfCourses_Venues_VenueId",
                table: "GolfCourses",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoleScore_Tee<HoleScore>_Tee<HoleScore>ScoreCardId_Tee<Hole~",
                table: "HoleScore",
                columns: new[] { "Tee<HoleScore>ScoreCardId", "Tee<HoleScore>Id" },
                principalTable: "Tee<HoleScore>",
                principalColumns: new[] { "ScoreCardId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Competitions_CompetitionId",
                table: "ScoreCards",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_GolfCourses_GolfCourseId",
                table: "ScoreCards",
                column: "GolfCourseId",
                principalTable: "GolfCourses",
                principalColumn: "GolfCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Players_PlayerId",
                table: "ScoreCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Venues_VenueId",
                table: "ScoreCards",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId");
        }
    }
}
